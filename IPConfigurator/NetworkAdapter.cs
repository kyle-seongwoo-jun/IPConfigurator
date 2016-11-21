using System;
using System.Collections.Generic;
using System.Management;

namespace IPConfigurator
{
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

		public Dictionary<string, string> IPInformation
		{
			get
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

		public void ToStaticIP(string ipAddress, string subnetMask = "255.255.255.0", string gateway = "10.156.145.1", string[] DNS = null)
		{
			DNS = DNS ?? new string[] { "210.111.226.7", "210.111.226.8" }; // Default value

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

		public override string ToString()
		{
			return Name;
		}
	}
}
