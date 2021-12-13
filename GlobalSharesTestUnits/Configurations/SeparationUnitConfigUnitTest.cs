using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Infrastructure.Implementations.Configurations;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;
using NUnit.Framework;

namespace GlobalSharesTestUnits.Configurations
{
	[TestFixture]
	public class SeparationUnitConfigUnitTest
	{
		private IConfigurations _configs;

		[SetUp]
		public void SetUp()
		{
			_configs = new BaseConfig("SeparationUnitConfig");
		}

		[Test]
		public void Get_PlatformConfig_UnitTest()
		{
			var position = _configs.GetPosition();

			Assert.True(position.AxisX == 5 && position.AxisY == 5);
		}
	}
}