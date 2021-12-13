using GlobalSharesAssignment.Infrastructure.Implementations.Configurations;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;
using NUnit.Framework;

namespace GlobalSharesTestUnits.Configurations
{
	[TestFixture]
	public class LandingAreaConfigUnitTest
	{
		private IConfigurations _configs;

		[SetUp]
		public void Setup()
		{
			_configs = new BaseConfig("LandingAreaConfig");
		}

		[Test]
		public void Get_LandingAreaConfig_UnitTest()
		{
			var position = _configs.GetPosition();

			Assert.True(position.AxisX == 100 && position.AxisY == 100);
		}
	}
}