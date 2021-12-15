using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Enums;
using GlobalSharesAssignment.Core.Interfaces.Rocket.LandingStatusStrategy;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;

namespace GlobalSharesAssignment.Core.Implementations.Rocket.LandingStatusStrategy
{
	public class OkForLandingStrategy : ILandingStatusStrategy
	{
		private readonly LandingPosition _landingPosition;
		private readonly IConfigurations _separationUnitConfig;
		private readonly IConfigurations _platformConfig;

		public OkForLandingStrategy(LandingPosition landingPosition, IConfigurations separationUnitConfig, IConfigurations platformConfig)
		{
			_landingPosition = landingPosition;
			_separationUnitConfig = separationUnitConfig;
			_platformConfig = platformConfig;
		}

		public string Execute()
		{
			var separationUnitConfigPosition = _separationUnitConfig.GetPosition();
			var platformConfig = _platformConfig.GetPosition();

			if(separationUnitConfigPosition == null || platformConfig == null)
			{
				return default;
			}

			return ((_landingPosition.Position.AxisX == separationUnitConfigPosition.AxisX && _landingPosition.Position.AxisY == separationUnitConfigPosition.AxisY) ||
				(_landingPosition.Position.AxisX <= platformConfig.AxisX && _landingPosition.Position.AxisY <= platformConfig.AxisY))
				? LandingStatus.OkForLanding.ToString()
				: default;
		}
	}
}
