using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Enums;

namespace GlobalSharesAssignment.Core.Interfaces.Rocket
{
	public interface IRocket
	{
		LandingStatus LandRocket(LandingPosition position);

	}
}
