using System;
using System.IO;
using System.Linq;
using GlobalSharesAssignment.Infrastructure.Helpers.Assembly;

namespace GlobalSharesAssignment.Infrastructure.Helpers.Configurations
{
	public static class ConfigurationFile
	{
		public static string GetConfigFilePath(Type targetConfigFileType)
		{
			var mainAssemblyPath = AssemblyReferences.GetAssemblyFiles(targetConfigFileType.Assembly).FirstOrDefault();
			var mainAssemblyDir = Path.GetDirectoryName(mainAssemblyPath ?? throw new FileNotFoundException(nameof(mainAssemblyPath)));
			var configFilesPath = Path.Combine(mainAssemblyDir ??
											   throw new DirectoryNotFoundException(nameof(mainAssemblyDir)), "Infrastructure", "Resources", "Configurations");

			return configFilesPath;
		}
	}
}
