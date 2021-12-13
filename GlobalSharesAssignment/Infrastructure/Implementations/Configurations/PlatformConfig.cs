using System;
using System.Drawing;
using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Infrastructure.Helpers.Configurations;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;
using Microsoft.Extensions.Configuration;

namespace GlobalSharesAssignment.Infrastructure.Implementations.Configurations
{
	public class PlatformConfig : IConfigurations
	{
		private readonly IConfigurationRoot _configurationRoot;

		public PlatformConfig()
		{
			_configurationRoot = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile($"{ConfigurationFile.GetConfigFilePath(typeof(PlatformConfig))}\\Platform.json")
				.Build();
		}

		public Position GetPosition()
		{
			var separationUnitWidth = _configurationRoot.GetSection("PlatformConfig:Size:AxisX").Value;
			var separationUnitWHeight = _configurationRoot.GetSection("PlatformConfig:Size:AxisY").Value;

			return new Position
			{
				AxisX = int.Parse(separationUnitWidth),
				AxisY = int.Parse(separationUnitWHeight)
			};
		}
	}
}
