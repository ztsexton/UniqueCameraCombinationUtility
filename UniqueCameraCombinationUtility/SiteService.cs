using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueCameraCombinationUtility
{
	public class SiteService
	{
		private readonly ISiteRepository _siteRepository;

		public SiteService(ISiteRepository siteRepository)
		{
			_siteRepository = siteRepository ?? throw new ArgumentNullException(typeof(SiteFileRepository).Name);
		}

		public Dictionary<string, int> GetUniqueCameraCombinations()
        {
            List<Site> siteCameraCombinations = _siteRepository.GetCameraCombinations();

            if (siteCameraCombinations == null)
            {
                return new Dictionary<string, int>();
            }

            var uniqueCameraCombinations = CreateUniqueCameraCombinationsMap(siteCameraCombinations);

            return uniqueCameraCombinations;
        }

        private Dictionary<string, int> CreateUniqueCameraCombinationsMap(List<Site> siteCameraCombinations)
        {
            var uniqueCameraCombinations = new Dictionary<string, int>();

            foreach (var site in siteCameraCombinations)
            {
                var sortedSiteCameras = site.Cameras.OrderBy(c => c).ToList();
                string key = string.Join(',', sortedSiteCameras);

                if (!uniqueCameraCombinations.ContainsKey(key))
                {
                    uniqueCameraCombinations.Add(key, 1);
                }
                else
                {
                    uniqueCameraCombinations[key]++;
                }
            }

            return uniqueCameraCombinations;
        }
    }

}
