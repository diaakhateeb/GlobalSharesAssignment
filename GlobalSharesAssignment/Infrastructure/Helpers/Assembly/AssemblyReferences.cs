using System.Collections.Generic;

namespace GlobalSharesAssignment.Infrastructure.Helpers.Assembly
{
	public static class AssemblyReferences
	{
		public static IEnumerable<string> GetAssemblyFiles(System.Reflection.Assembly assembly)
		{
			yield return assembly.Location;

			foreach (var assemblyName in assembly.GetReferencedAssemblies())
			{
				yield return System.Reflection.Assembly.ReflectionOnlyLoad(assemblyName.FullName).Location;
			}
		}
	}
}
