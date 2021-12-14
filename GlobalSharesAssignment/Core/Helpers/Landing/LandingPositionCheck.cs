using GlobalSharesAssignment.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GlobalSharesAssignment.Core.Helpers.Landing
{
	internal static class LandingPositionCheck
	{
		internal static LandingPosition CheckedBefore(LandingPosition landingPosition, ICollection<LandingPosition> positionsCheckedBefore)
		{
			var landPos = positionsCheckedBefore.FirstOrDefault(x => JsonConvert.SerializeObject(x) == JsonConvert.SerializeObject(landingPosition));

			if (landPos == null)
			{
				positionsCheckedBefore.Add(landingPosition);
			}

			return landPos;
		}
	}
}
