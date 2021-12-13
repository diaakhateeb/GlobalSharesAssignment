using GlobalSharesAssignment.Core.Implementations.Rocket.LandingStatusStrategy;
using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Enums;
using System.Collections.Generic;
using GlobalSharesAssignment.Core.Interfaces.Rocket.LandingStatusStrategy;
using GlobalSharesAssignment.Infrastructure.Implementations.Configurations;

namespace GlobalSharesAssignment.Core.Patterns.LandingStatusFactory
{
	public class LandingStatusFactory
	{
		private static readonly IDictionary<LandingStatus, ILandingStatusStrategy> Strategies =
			new Dictionary<LandingStatus, ILandingStatusStrategy>();

		public LandingStatusFactory(ICollection<LandingPosition> positionsCheckedBefore, LandingPosition landingPosition)
		{
			Strategies[LandingStatus.OkForLanding] = new OkForLandingStrategy(landingPosition, new SeparationUnitConfig(), new PlatformConfig());
			Strategies[LandingStatus.OutOfPlatform] = new OutOfPlatformStrategy(landingPosition, new SeparationUnitConfig(), new PlatformConfig());
			Strategies[LandingStatus.Clash] = new ClashStrategy(positionsCheckedBefore, landingPosition, new SeparationUnitConfig());
		}

		public ILandingStatusStrategy GetStrategy(LandingStatus status)
		{
			return Strategies[status];
		}
	}
}
