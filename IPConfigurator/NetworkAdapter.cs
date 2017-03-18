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
                        var ip = (adapter["IPAddress"] as string[]) ?? new[] { "" };
                        var subnetMask = (adapter["IPSubnet"] as string[]) ?? new[] { "" };
                        var gateway = (adapter["DefaultIPGateway"] as string[]) ?? new[] { "" };
                        var dns = (adapter["DNSServerSearchOrder"] as string[]) ?? new[] { "" };

                        dic.Add("IP Address", string.Join(", ", ip));
                        dic.Add("Subnet Mask", string.Join(", ", subnetMask));
                        dic.Add("Gateway", string.Join(", ", gateway));
                        dic.Add("DNS Server", string.Join(", ", dns));
                        
                        return dic;
					}
				}

				throw new Exception();
			}
		}

		public void ToStaticIP(string ipAddress, string subnetMask, string gateway, string[] DNS)
		{
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
                    ManagementBaseObject newGateway = adapter.GetMethodParameters("SetGateways");
                    newGateway["DefaultIPGateway"] = null;
                    newGateway["GatewayCostMetric"] = new int[] { 0 };

                    ManagementBaseObject nullDNS = adapter.GetMethodParameters("SetDNSServerSearchOrder");
					nullDNS["DNSServerSearchOrder"] = null;

					adapter.InvokeMethod("EnableDHCP", null);
                    adapter.InvokeMethod("SetGateways", newGateway, null);
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
