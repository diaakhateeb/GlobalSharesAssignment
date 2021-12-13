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
			return ((_landingPosition.Position.AxisX == _separationUnitConfig.GetPosition().AxisX && _landingPosition.Position.AxisY == _separationUnitConfig.GetPosition().AxisY) ||
				   (_landingPosition.Position.AxisX <= _platformConfig.GetPosition().AxisX && _landingPosition.Position.AxisY <= _platformConfig.GetPosition().AxisY))
				? LandingStatus.OkForLanding.ToString()
				: default;
		}
	}
}
