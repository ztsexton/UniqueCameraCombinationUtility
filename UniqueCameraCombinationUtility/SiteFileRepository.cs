using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UniqueCameraCombinationUtility
{
	public class SiteFileRepository : ISiteRepository
	{
		private const string FileName = "sites.json";
		private readonly string _filePath = Path.Combine(Environment.CurrentDirectory, FileName);

		public List<Site> GetCameraCombinations()
		{
			try
			{
				var options = new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				};

				var siteData = File.ReadAllText(_filePath);
				var sites = JsonSerializer.Deserialize<List<Site>>(siteData, options);

				return sites;
			}
			catch (Exception)
			{
				Console.WriteLine("An error has occurred when reading data from the file.");
				return new List<Site>();
			}
		}
	}
}
