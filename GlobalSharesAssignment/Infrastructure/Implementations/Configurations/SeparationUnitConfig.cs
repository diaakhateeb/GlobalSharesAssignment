using System;
using System.Drawing;
using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Infrastructure.Helpers.Configurations;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;
using Microsoft.Extensions.Configuration;

namespace GlobalSharesAssignment.Infrastructure.Implementations.Configurations
{
	public class SeparationUnitConfig : IConfigurations
	{
		private readonly IConfigurationRoot _configurationRoot;
		public SeparationUnitConfig()
		{
			_configurationRoot = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile($"{ConfigurationFile.GetConfigFilePath(typeof(SeparationUnitConfig))}\\SeparationUnit.json")
				.Build();
		}

		public Position GetPosition()
		{
			var separationUnitWidth = _configurationRoot.GetSection("SeparationUnitConfig:Size:AxisX").Value;
			var separationUnitWHeight = _configurationRoot.GetSection("SeparationUnitConfig:Size:AxisY").Value;

			return new Position
			{
				AxisX = int.Parse(separationUnitWidth),
				AxisY = int.Parse(separationUnitWHeight)
			};
		}
	}
}
