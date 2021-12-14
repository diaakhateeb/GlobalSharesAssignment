using GlobalSharesAssignment.Core.Helpers.Landing;
using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using GlobalSharesAssignment.Core.Interfaces.Rocket.LandingStatusStrategy;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;

namespace GlobalSharesAssignment.Core.Implementations.Rocket.LandingStatusStrategy
{
	public class ClashStrategy : ILandingStatusStrategy
	{
		private readonly ICollection<LandingPosition> _positionsCheckedBefore;
		private readonly LandingPosition _landingPosition;
		private readonly IConfigurations _configuration;

		public ClashStrategy(ICollection<LandingPosition> positionsCheckedBefore, LandingPosition landingPosition, IConfigurations configuration)
		{
			_positionsCheckedBefore = positionsCheckedBefore;
			_landingPosition = landingPosition;
			_configuration = configuration;
		}

		public string Execute()
		{
			var pos = _configuration.GetPosition();

			if ((from position in _positionsCheckedBefore
				 let axisXMax = Math.Max(position.Position.AxisX, _landingPosition.Position.AxisX)
				 let axisYMax = Math.Max(position.Position.AxisY, _landingPosition.Position.AxisY)
				 let axisXMin = Math.Min(position.Position.AxisX, _landingPosition.Position.AxisX)
				 let axisYMin = Math.Min(position.Position.AxisY, _landingPosition.Position.AxisY)
				 where axisXMax - axisXMin < pos.AxisX && axisYMax - axisYMin < pos.AxisY
				 select axisXMax).Any())
			{
				return LandingStatus.Clash.ToString();
			}

			var landingPos = LandingPositionCheck.CheckedBefore(_landingPosition, _positionsCheckedBefore);

			return landingPos != null ? LandingStatus.Clash.ToString() : default;
		}
	}
}
