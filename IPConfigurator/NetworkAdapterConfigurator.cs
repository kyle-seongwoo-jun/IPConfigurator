using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace IPConfigurator
{
	class NetworkAdapterConfigurator
	{
		ManagementClass adapterConfig;
		ManagementObjectCollection networkCollection;

		public NetworkAdapterConfigurator()
		{
			adapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
			networkCollection = adapterConfig.GetInstances();
		}

		public List<string> NetworkAdapter
		{
			get
			{
				networkCollection = adapterConfig.GetInstances();
				List<string> list = new List<string>();

				foreach (ManagementObject adapter in networkCollection)
				{
					if ((bool)adapter["IPEnabled"])
					{
						list.Add(adapter["Description"] as string);
					}
				}
				return list;
			}
		}

		public bool IsDynamic(string adapterName)
		{
			foreach (ManagementObject adapter in networkCollection)
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
			foreach (ManagementObject adapter in networkCollection)
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
			foreach (ManagementObject adapter in networkCollection)
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

		public string[] GetIP(string adapterName)
		{
			List<string> list = new List<string>();

			foreach (ManagementObject adapter in networkCollection)
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
}
