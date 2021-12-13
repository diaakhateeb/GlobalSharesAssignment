using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Enums;

namespace GlobalSharesAssignment.Core.Interfaces.Landing
{
	public interface ILanding
	{
		LandingStatus DoLand(LandingPosition landingPosition);
	}
}
