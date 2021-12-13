using GlobalSharesAssignment.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
