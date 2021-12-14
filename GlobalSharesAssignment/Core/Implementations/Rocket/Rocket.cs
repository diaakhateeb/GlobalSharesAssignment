using GlobalSharesAssignment.Core.Interfaces.Landing;
using GlobalSharesAssignment.Core.Interfaces.Rocket;
using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Enums;

namespace GlobalSharesAssignment.Core.Implementations.Rocket
{
	public class Rocket : IRocket
	{
		private readonly ILanding _landing;

		public Rocket(ILanding landing)
		{
			_landing = landing;
		}
		public LandingStatus LandRocket(LandingPosition position)
		{
			return _landing.DoLand(position);
		}
	}
}
