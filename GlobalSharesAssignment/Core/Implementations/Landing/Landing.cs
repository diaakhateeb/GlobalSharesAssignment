using GlobalSharesAssignment.Core.Interfaces.Landing;
using GlobalSharesAssignment.Core.Patterns.LandingStatusFactory;
using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Enums;
using System.Collections.Generic;
using System;
using System.Linq;

namespace GlobalSharesAssignment.Core.Implementations.Landing
{
	public class Landing : ILanding
	{
		private static ICollection<LandingPosition> _positionsCheckedBefore;
		public Landing()
		{
			_positionsCheckedBefore = new List<LandingPosition>();
		}
		public LandingStatus DoLand(LandingPosition landingPosition)
		{
			var landingStatusResult = string.Empty;

			var factory = new LandingStatusFactory(_positionsCheckedBefore, landingPosition);
			var landingStatusProxiesList = new List<LandingStatusProxy>
			{
				new LandingStatusProxy(LandingStatus.Clash),
				new LandingStatusProxy(LandingStatus.OkForLanding),
				new LandingStatusProxy(LandingStatus.OutOfPlatform)
			};

			foreach (var landingStatusStrategy in landingStatusProxiesList.Select(landingStatusProxy => factory.GetStrategy(landingStatusProxy.CurrentStatus)))
			{
				landingStatusResult = landingStatusStrategy.Execute();
				if (!string.IsNullOrEmpty(landingStatusResult))
				{
					break;
				}
			}

			return (LandingStatus)Enum.Parse(typeof(LandingStatus), landingStatusResult ?? throw new InvalidOperationException(nameof(landingStatusResult)));
		}
	}
}
