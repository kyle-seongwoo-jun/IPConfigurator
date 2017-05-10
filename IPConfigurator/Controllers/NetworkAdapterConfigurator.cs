using System;
using System.Collections.Generic;
using System.Management;

using IPConfigurator.Models;

namespace IPConfigurator.Controllers
{
	public class NetworkAdapterConfigurator
	{
		ManagementClass WMI;
		ManagementObjectCollection networkAdapterCollection;

		public NetworkAdapterConfigurator()
		{
			WMI = new ManagementClass("Win32_NetworkAdapterConfiguration");
			networkAdapterCollection = WMI.GetInstances();
		}

		public List<NetworkAdapter> NetworkAdapters
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
	}
}
