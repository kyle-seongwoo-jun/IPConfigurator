using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace IPConfigurator
{
	class NetworkAdapterConfigurator
	{
		ManagementClass WMI;
		ManagementObjectCollection networkAdapterCollection;

		public NetworkAdapterConfigurator()
		{
			WMI = new ManagementClass("Win32_NetworkAdapterConfiguration");
			networkAdapterCollection = WMI.GetInstances();
		}

		private void reloadNetworkAdapter()
		{
			networkAdapterCollection = WMI.GetInstances();
		}

		public List<string> NetworkAdapters
		{
			get
			{
				reloadNetworkAdapter();

				List<string> list = new List<string>();

				foreach (ManagementObject adapter in networkAdapterCollection)
				{
					if ((bool)adapter["IPEnabled"])
					{
						list.Add(adapter["Description"] as string);
					}
				}
				return list;
			}
		}

		public List<NetworkAdapter> NetworkAdapter
		{
			get
			{
				var list = new List<NetworkAdapter>();

				foreach (var adapter in networkAdapterCollection)
				{
					if ((bool)adapter["IPEnabled"])
					{
						list.Add(new NetworkAdapter(WMI, adapter["Description"] as string));
					}
				}
				return list;
			}
		}

		public bool IsDynamic(string adapterName)
		{
			foreach (ManagementObject adapter in networkAdapterCollection)
			{
				if (adapterName.Equals(adapter["Description"]))
				{
					return (bool)adapter["DHCPEnabled"];
				}
			}

			// TODO: Make new Exception class
			throw new Exception();
		}

		public void ToStaticIP(string adapterName, string ipAddress, string subnetMask = "255.255.255.0", string gateway = "10.156.145.1", string DNS = "210.111.226.7,210.111.226.8")
		{
			foreach (ManagementObject adapter in networkAdapterCollection)
			{
				if (adapterName.Equals(adapter["Description"]))
				{
					// Set IPAddress and Subnet Mask
					ManagementBaseObject newAddress = adapter.GetMethodParameters("EnableStatic");
					newAddress["IPAddress"] = new string[] { ipAddress };
					newAddress["SubnetMask"] = new string[] { subnetMask };

					// Set DefaultGateway
					ManagementBaseObject newGateway = adapter.GetMethodParameters("SetGateways");
					newGateway["DefaultIPGateway"] = new string[] { gateway };
					newGateway["GatewayCostMetric"] = new int[] { 1 };

					// Set DNS server 
					ManagementBaseObject newDNS = adapter.GetMethodParameters("SetDNSServerSearchOrder");
					newDNS["DNSServerSearchOrder"] = DNS.Split(',');

					// Configurate
					adapter.InvokeMethod("EnableStatic", newAddress, null);
					adapter.InvokeMethod("SetGateways", newGateway, null);
					adapter.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);

					//TODO: These three Method has return value...
				}
			}
		}

		public void ToDynamicIP(string adapterName)
		{
			foreach (ManagementObject adapter in networkAdapterCollection)
			{
				if (adapterName.Equals(adapter["Description"]))
				{
					ManagementBaseObject nullDNS = adapter.GetMethodParameters("SetDNSServerSearchOrder");
					nullDNS["DNSServerSearchOrder"] = null;

					adapter.InvokeMethod("EnableDHCP", null);
					adapter.InvokeMethod("SetDNSServerSearchOrder", nullDNS, null);

					return;
				}
			}

			throw new Exception();
		}

		public string[] IPInformation(string adapterName)
		{
			List<string> list = new List<string>();

			foreach (ManagementObject adapter in networkAdapterCollection)
			{
				if (adapterName.Equals(adapter["Description"]))
				{
					string ip = (adapter["IPAddress"] as string[])[0];
					string subnetMask = (adapter["IPSubnet"] as string[])[0];
					string gateway = (adapter["DefaultIPGateway"] as string[])[0];
					string[] dns = (adapter["DNSServerSearchOrder"] as string[]);

					list.Add("IP Address : " + ip);
					list.Add("Subnet Mask : " + subnetMask);
					list.Add("Default Gateway : " + gateway);
					list.Add("DNS Server : " + dns[0]);

					if (dns.Length > 1)
					{
						list[3] += ", " + dns[1];
					}

					return list.ToArray();
				}
			}

			throw new Exception();
		}
	}

	class NetworkAdapter
	{
		/// <summary>
		/// Win32_NetworkAdapterConfiguration WMI class
		/// </summary>
		ManagementClass WMI;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="wmi">Win32_NetworkAdapterConfiguration ManagementClass object</param>
		/// <param name="adapter">Network adapter name</param>
		public NetworkAdapter(ManagementClass wmi, string adapter)
		{
			WMI = wmi;
			Name = adapter;
		}

		/// <summary>
		/// Adapter Name
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// If it is false, this adapter is static IP else it is dynamic ip 
		/// </summary>
		public bool IsDynamic
		{
			get
			{
				foreach (ManagementObject adapter in WMI.GetInstances())
				{
					if (Name.Equals(adapter["Description"]))
					{
						return (bool)adapter["DHCPEnabled"];
					}
				}

				// TODO: Make new Exception class
				throw new Exception();
			}
		}

		public override string ToString()
		{
			return Name;
		}

		public void ToStaticIP(string ipAddress, string subnetMask = "255.255.255.0", string gateway = "10.156.145.1", string[] DNS = null)
		{
			DNS = DNS ?? new string[] { "210.111.226.7", "210.111.226.8" };	// Default value

			foreach (ManagementObject adapter in WMI.GetInstances())
			{
				if (Name.Equals(adapter["Description"]))
				{
					// Set IPAddress and Subnet Mask
					ManagementBaseObject newAddress = adapter.GetMethodParameters("EnableStatic");
					newAddress["IPAddress"] = new string[] { ipAddress };
					newAddress["SubnetMask"] = new string[] { subnetMask };

					// Set DefaultGateway
					ManagementBaseObject newGateway = adapter.GetMethodParameters("SetGateways");
					newGateway["DefaultIPGateway"] = new string[] { gateway };
					newGateway["GatewayCostMetric"] = new int[] { 1 };

					// Set DNS server 
					ManagementBaseObject newDNS = adapter.GetMethodParameters("SetDNSServerSearchOrder");
					newDNS["DNSServerSearchOrder"] = DNS;

					// Configurate
					adapter.InvokeMethod("EnableStatic", newAddress, null);
					adapter.InvokeMethod("SetGateways", newGateway, null);
					adapter.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);

					//TODO: These three Method has return value...
				}
			}
		}

		public void ToDynamicIP()
		{
			foreach (ManagementObject adapter in WMI.GetInstances())
			{
				if (Name.Equals(adapter["Description"]))
				{
					ManagementBaseObject nullDNS = adapter.GetMethodParameters("SetDNSServerSearchOrder");
					nullDNS["DNSServerSearchOrder"] = null;

					adapter.InvokeMethod("EnableDHCP", null);
					adapter.InvokeMethod("SetDNSServerSearchOrder", nullDNS, null);
				}
			}
		}

		public Dictionary<string, string> IPInformation()
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();

			foreach (ManagementObject adapter in WMI.GetInstances())
			{
				if (Name.Equals(adapter["Description"]))
				{
					string ip = (adapter["IPAddress"] as string[])[0];
					string subnetMask = (adapter["IPSubnet"] as string[])[0];
					string gateway = (adapter["DefaultIPGateway"] as string[])[0];
					string[] dns = (adapter["DNSServerSearchOrder"] as string[]);

					dic.Add("IP Address", ip);
					dic.Add("Subnet Mask", subnetMask);
					dic.Add("Gateway", gateway);
					dic.Add("DNS Server", dns[0]);

					if (dns.Length > 1)
					{
						dic["DNS Server"] += $", {dns[1]}";
					}

					return dic;
				}
			}

			throw new Exception();
		}
	}
}
