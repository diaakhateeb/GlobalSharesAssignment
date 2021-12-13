using GlobalSharesAssignment.Enums;

namespace GlobalSharesAssignment.Core.Implementations.Landing
{
	public class LandingStatusProxy
	{
		public LandingStatusProxy(LandingStatus status)
		{
			CurrentStatus = status;
		}
		public LandingStatus CurrentStatus { get; set; }
	}
}
