using System;
using GlobalSharesAssignment.Entities;
using GlobalSharesAssignment.Infrastructure.Helpers.Configurations;
using GlobalSharesAssignment.Infrastructure.Interfaces.Configurations;
using Microsoft.Extensions.Configuration;

namespace GlobalSharesAssignment.Infrastructure.Implementations.Configurations
{
	public class BaseConfig : IConfigurations
	{
		private readonly IConfigurationRoot _configurationRoot;
		private readonly string _targetConfigName;

		public BaseConfig(string targetConfigName)
		{
			_targetConfigName = targetConfigName;

			_configurationRoot = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile($"{ConfigurationFile.GetConfigFilePath(typeof(BaseConfig))}\\{targetConfigName}.json")
				.Build();
		}

		public Position GetPosition()
		{
			var axisX = _configurationRoot.GetSection($"{_targetConfigName}:Size:AxisX").Value;
			var axisY = _configurationRoot.GetSection($"{_targetConfigName}:Size:AxisY").Value;

			return new Position
			{
				AxisX = int.Parse(axisX),
				AxisY = int.Parse(axisY)
			};
		}
	}
}
