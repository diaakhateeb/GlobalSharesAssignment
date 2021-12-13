using GlobalSharesAssignment.Infrastructure.Implementations.Configurations;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;
using NUnit.Framework;

namespace GlobalSharesTestUnits.Configurations
{
	[TestFixture]
	public class PlatformConfigUnitTest
	{
		private IConfigurations _configs;

		[SetUp]
		public void SetUp()
		{
			_configs = new PlatformConfig();
		}

		[Test]
		public void Get_PlatformConfig_UnitTest()
		{
			var position = _configs.GetPosition();

			Assert.True(position.AxisX == 15 && position.AxisY == 15);
		}
	}
}
