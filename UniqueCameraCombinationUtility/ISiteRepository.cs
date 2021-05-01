using System.Collections.Generic;

namespace UniqueCameraCombinationUtility
{
	public interface ISiteRepository
	{
		List<Site> GetCameraCombinations();
	}
}