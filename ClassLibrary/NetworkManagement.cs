using System;
using System.Management;
using System.Collections.Generic;

namespace ClassLibrary
{ 
	public class NetworkAdapterConfiguration
	{
		ManagementClass adapterConfig;
		ManagementObjectCollection networkCollection;
		
		public NetworkAdapterConfiguration()
		{
			adapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
			networkCollection = adapterConfig.GetInstances();
		}

		public string[] FindNetworkAdapter()
		{
			networkCollection = adapterConfig.GetInstances();
			List<string> temp = new List<string>();

			foreach (ManagementObject adapter in networkCollection)
			{
				if ((bool)adapter["IPEnabled"])
				{
					temp.Add(adapter["Description"] as string);
				}
			}
			return temp.ToArray();
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
					adapter.InvokeMethod("EnableDHCP", null);

					ManagementBaseObject obj_dns = adapter.GetMethodParameters("EnableDNS");
					obj_dns["DNSServerSearchOrder"] = "210.111.226.7,210.111.226.8".Split(',');
					adapter.InvokeMethod("EnableDNS", obj_dns, null);
					
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
