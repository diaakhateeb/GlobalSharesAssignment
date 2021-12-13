using System;
using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Infrastructure.Helpers.Configurations;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;
using Microsoft.Extensions.Configuration;

namespace GlobalSharesAssignment.Infrastructure.Implementations.Configurations
{
	public class LandingAreaConfig : IConfigurations
	{
		private readonly IConfigurationRoot _configurationRoot;
		public LandingAreaConfig()
		{
			_configurationRoot = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile($"{ConfigurationFile.GetConfigFilePath(typeof(LandingAreaConfig))}\\LandingArea.json")
				.Build();
		}

		public Position GetPosition()
		{
			var separationUnitAxisX = _configurationRoot.GetSection("LandingAreaConfig:Size:AxisX").Value;
			var separationUnitWAxisY = _configurationRoot.GetSection("LandingAreaConfig:Size:AxisY").Value;

			return new Position
			{
				AxisX = int.Parse(separationUnitAxisX),
				AxisY = int.Parse(separationUnitWAxisY)
			};
		}
	}
}
