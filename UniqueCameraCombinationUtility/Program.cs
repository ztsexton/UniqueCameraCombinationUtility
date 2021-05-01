using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueCameraCombinationUtility
{
	class Program
	{
		static void Main(string[] args)
		{
			var siteRepository = new SiteFileRepository();
			var siteService = new SiteService(siteRepository);

			Dictionary<string, int> uniqueCameraCombinations = siteService.GetUniqueCameraCombinations();

			if (uniqueCameraCombinations.Count == 0)
			{
				Console.WriteLine("There was a problem reading site data.");
			}
			else
			{
				uniqueCameraCombinations = SortCameraCombinations(uniqueCameraCombinations);
				PrintCameraCombinationResults(uniqueCameraCombinations);
			}

			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}

		private static void PrintCameraCombinationResults(Dictionary<string, int> uniqueCameraCombinations)
		{
			foreach (var key in uniqueCameraCombinations.Keys)
			{
				Console.WriteLine($"{uniqueCameraCombinations[key]} - {key}");
			}
		}

		private static Dictionary<string, int> SortCameraCombinations(Dictionary<string, int> uniqueCameraCombinations)
		{
			return uniqueCameraCombinations.OrderByDescending(x => x.Value)
										   .ThenBy(x => x.Key)
										   .ToDictionary(x => x.Key, x => x.Value);
		}
	}
}
