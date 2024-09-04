using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPConfigurator.Controllers;
using static System.Console;

namespace IPConfigurator.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			string command = args[0];

			if (command == "list")
			{
				var configurator = NetworkAdapterConfigurator.Instance;

				var adapters = configurator.NetworkAdapters;

				foreach (var item in adapters)
				{
					WriteLine(item);
				}
			}
		}
	}

	interface ICommandLineInteractive
	{
		string OnListCommand();

		string OnHelpCommand();
	}
}
