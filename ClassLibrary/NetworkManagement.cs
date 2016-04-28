using System;
using System.Management;
using System.Collections.Generic;

namespace ClassLibrary
{
	class NetworkManagement
	{
		ManagementClass objMC;
		ManagementObjectCollection objMOC;

		public NetworkManagement()
		{
			objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
			objMOC = objMC.GetInstances();
		}

		/// <summary>
		/// Set's a new IP Address and it's Submask of the local machine
		/// </summary>
		/// <param name="ipAddress">The IP Address</param>
		/// <param name="subnetMask">The Submask IP Address</param>
		/// <remarks>Requires a reference to the System.Management namespace</remarks>
		public void setIP(string ipAddress, string subnetMask)
		{
			foreach (ManagementObject objMO in objMOC)
			{
				if ((bool)objMO["IPEnabled"])
				{
					try
					{
						ManagementBaseObject setIP;
						ManagementBaseObject newIP =
							objMO.GetMethodParameters("EnableStatic");

						newIP["IPAddress"] = new string[] { ipAddress };
						newIP["SubnetMask"] = new string[] { subnetMask };

						setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
					}
					catch (Exception)
					{
						throw;
					}


				}
			}
		}
		
		/// <summary>
		/// Set's a new Gateway address of the local machine
		/// </summary>
		/// <param name="gateway">The Gateway IP Address</param>
		/// <remarks>Requires a reference to the System.Management namespace</remarks>
		public void setGateway(string gateway)
		{
			foreach (ManagementObject objMO in objMOC)
			{
				if ((bool)objMO["IPEnabled"])
				{
					try
					{
						ManagementBaseObject setGateway;
						ManagementBaseObject newGateway =
							objMO.GetMethodParameters("SetGateways");

						newGateway["DefaultIPGateway"] = new string[] { gateway };
						newGateway["GatewayCostMetric"] = new int[] { 1 };

						setGateway = objMO.InvokeMethod("SetGateways", newGateway, null);
					}
					catch (Exception)
					{
						throw;
					}
				}
			}
		}
		
		/// <summary>
		/// Set's the DNS Server of the local machine
		/// </summary>
		/// <param name="NIC">NIC address</param>
		/// <param name="DNS">DNS server address</param>
		/// <remarks>Requires a reference to the System.Management namespace</remarks>
		public void setDNS(string NIC, string DNS)
		{
			foreach (ManagementObject objMO in objMOC)
			{
				if ((bool)objMO["IPEnabled"])
				{
					// if you are using the System.Net.NetworkInformation.NetworkInterface you'll need to change this line to if (objMO["Caption"].ToString().Contains(NIC)) and pass in the Description property instead of the name 
					if (objMO["Caption"].Equals(NIC))
					{
						try
						{
							ManagementBaseObject newDNS =
								objMO.GetMethodParameters("SetDNSServerSearchOrder");
							newDNS["DNSServerSearchOrder"] = DNS.Split(',');
							ManagementBaseObject setDNS =
								objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
						}
						catch (Exception)
						{
							throw;
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Set's WINS of the local machine
		/// </summary>
		/// <param name="NIC">NIC Address</param>
		/// <param name="priWINS">Primary WINS server address</param>
		/// <param name="secWINS">Secondary WINS server address</param>
		/// <remarks>Requires a reference to the System.Management namespace</remarks>
		public void setWINS(string NIC, string priWINS, string secWINS)
		{
			foreach (ManagementObject objMO in objMOC)
			{
				if ((bool)objMO["IPEnabled"])
				{
					if (objMO["Caption"].Equals(NIC))
					{
						try
						{
							ManagementBaseObject setWINS;
							ManagementBaseObject wins =
							objMO.GetMethodParameters("SetWINSServer");
							wins.SetPropertyValue("WINSPrimaryServer", priWINS);
							wins.SetPropertyValue("WINSSecondaryServer", secWINS);

							setWINS = objMO.InvokeMethod("SetWINSServer", wins, null);
						}
						catch (Exception)
						{
							throw;
						}
					}
				}
			}
		}
	}

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
					adapter.InvokeMethod("EnableDNS", null);
				}
			}

			throw new Exception();
		}
	}
}
