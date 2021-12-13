using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Enums;
using GlobalSharesAssignment.Core.Interfaces.Rocket.LandingStatusStrategy;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;

namespace GlobalSharesAssignment.Core.Implementations.Rocket.LandingStatusStrategy
{
	public class OutOfPlatformStrategy : ILandingStatusStrategy
	{
		private readonly LandingPosition _landingPosition;
		private readonly IConfigurations _separationUnitConfig;
		private readonly IConfigurations _platformConfig;
		public OutOfPlatformStrategy(LandingPosition landingPosition, IConfigurations separationUnitConfig, IConfigurations platformConfig)
		{
			_landingPosition = landingPosition;
			_separationUnitConfig = separationUnitConfig;
			_platformConfig = platformConfig;
		}
		public string Execute()
		{
			return (_landingPosition.Position.AxisX + _separationUnitConfig.GetPosition().AxisX > _platformConfig.GetPosition().AxisX ||
					_landingPosition.Position.AxisY + _separationUnitConfig.GetPosition().AxisY > _platformConfig.GetPosition().AxisY ||
				   (_landingPosition.Position.AxisX < _separationUnitConfig.GetPosition().AxisX || _landingPosition.Position.AxisY < _separationUnitConfig.GetPosition().AxisY))
				? LandingStatus.OutOfPlatform.ToString()
				: default;
		}
	}
}
