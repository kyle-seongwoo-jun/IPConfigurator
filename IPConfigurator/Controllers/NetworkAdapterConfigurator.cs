using System;
using System.Collections.Generic;
using System.Management;

using IPConfigurator.Models;

namespace IPConfigurator.Controllers
{
	public class NetworkAdapterConfigurator
	{
		static readonly Lazy<NetworkAdapterConfigurator> instance = new Lazy<NetworkAdapterConfigurator>(() => new NetworkAdapterConfigurator());
		public static NetworkAdapterConfigurator Instance => instance.Value;

		ManagementClass WMI;
		ManagementObjectCollection networkAdapterCollection;

		protected NetworkAdapterConfigurator()
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
						list.Add(new NetworkAdapter(WMI, adapter));
					}
				}
				return list;
			}
		}
	}
}
