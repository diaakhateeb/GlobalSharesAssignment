using System;
using System.Linq;
using System.Threading.Tasks;
using GlobalSharesAssignment.Core.Implementations.Landing;
using GlobalSharesAssignment.Core.Interfaces.Rocket;
using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Enums;
using NUnit.Framework;
using Xunit;

namespace GlobalSharesTestUnits.Rocket
{
	[TestFixture]
	public class RocketUnitTests
	{
		private IRocket _rocket;
		private static Position _position;

		[SetUp]
		public void SetUp()
		{
			_rocket = new GlobalSharesAssignment.Core.Implementations.Rocket.Rocket(new Landing());
			_position = new Position();
		}

		[Test]
		public void Position_5_5_Returns_OkForLanding_UnitTest()
		{
			var landingStatus = _rocket.LandRocket(new LandingPosition
			{
				Position = new Position
				{
					AxisX = 5,
					AxisY = 5
				}
			});

			Assert.AreEqual(Enum.GetName(typeof(LandingStatus), LandingStatus.OkForLanding), landingStatus.ToString());
		}

		[Test]
		public void Position_16_15_Returns_OutOfPlatform_UnitTest()
		{
			var landingStatus = _rocket.LandRocket(new LandingPosition
			{
				Position = new Position
				{
					AxisX = 16,
					AxisY = 15
				}
			});

			Assert.AreEqual(Enum.GetName(typeof(LandingStatus), LandingStatus.OutOfPlatform), landingStatus.ToString());
		}

		[Test]
		public void PositionPreviouslyChecked_Returns_Clash_UnitTest()
		{
			var rocket1LandingStatus = _rocket.LandRocket(new LandingPosition
			{
				Position = new Position
				{
					AxisX = 7,
					AxisY = 7
				}
			});
			Assert.AreEqual(Enum.GetName(typeof(LandingStatus), LandingStatus.OkForLanding), rocket1LandingStatus.ToString());

			var rocket2LandingStatus = _rocket.LandRocket(new LandingPosition
			{
				Position = new Position
				{
					AxisX = 7,
					AxisY = 7
				}
			});
			Assert.AreEqual(Enum.GetName(typeof(LandingStatus), LandingStatus.Clash), rocket2LandingStatus.ToString());
		}

		[Test]
		public void SideBySidePosition_Returns_Clash_UnitTest()
		{
			_position.AxisX = 6;
			_position.AxisY = 5;
			var rocket1LandingStatus = _rocket.LandRocket(new LandingPosition
			{
				Position = _position
			});
			Assert.AreEqual(Enum.GetName(typeof(LandingStatus), LandingStatus.OkForLanding), rocket1LandingStatus.ToString());

			_position = new Position { AxisX = 10, AxisY = 5 };
			var rocket2LandingStatus = _rocket.LandRocket(new LandingPosition
			{
				Position = _position
			});
			Assert.AreEqual(Enum.GetName(typeof(LandingStatus), LandingStatus.Clash), rocket2LandingStatus.ToString());
		}

		[Test]
		public void SideBySidePosition_Returns_OkForLanding_UnitTest()
		{
			_position.AxisX = 6;
			_position.AxisY = 5;
			var rocket1LandingStatus = _rocket.LandRocket(new LandingPosition
			{
				Position = _position
			});
			Assert.AreEqual(Enum.GetName(typeof(LandingStatus), LandingStatus.OkForLanding), rocket1LandingStatus.ToString());

			_position = new Position { AxisX = 11, AxisY = 5 };
			var rocket2LandingStatus = _rocket.LandRocket(new LandingPosition
			{
				Position = _position
			});
			Assert.AreEqual(Enum.GetName(typeof(LandingStatus), LandingStatus.OkForLanding), rocket2LandingStatus.ToString());
		}

		[Test]
		public void Parallel_Landing_Returns_Clash_UnitTest_()
		{
			var rocket1LandingStatusTask = Task.Run(() =>
			{
				_position.AxisX = 6;
				_position.AxisY = 5;

				return _rocket.LandRocket(new LandingPosition
				{
					Position = _position
				});
			});

			var rocket2LandingStatusTask = Task.Run(() =>
			{
				_position = new Position { AxisX = 10, AxisY = 5 };

				return _rocket.LandRocket(new LandingPosition
				{
					Position = _position
				});
			});

			var taskLandingArray = new Task<LandingStatus>[]
			{
					rocket1LandingStatusTask,
					rocket2LandingStatusTask
			};

			var result = Task.WhenAll(taskLandingArray).Result;

			var clashCount = result.Count(x => x == LandingStatus.Clash);

			Assert.True(clashCount == 1);
		}

		[Test]
		public void Parallel_Landing_Returns_OkForLanding_UnitTest_()
		{
			var rocket1LandingStatusTask = Task.Run(() =>
			{
				_position.AxisX = 6;
				_position.AxisY = 5;

				return _rocket.LandRocket(new LandingPosition
				{
					Position = _position
				});
			});

			var rocket2LandingStatusTask = Task.Run(() =>
			{
				_position = new Position { AxisX = 11, AxisY = 5 };

				return _rocket.LandRocket(new LandingPosition
				{
					Position = _position
				});
			});

			var taskLandingArray = new Task<LandingStatus>[]
			{
				rocket1LandingStatusTask,
				rocket2LandingStatusTask

			};

			var result = Task.WhenAll(taskLandingArray).Result;

			var okForLandingCount = result.Count(x => x == LandingStatus.OkForLanding);

			Assert.True(okForLandingCount == 2);
		}
	}
}