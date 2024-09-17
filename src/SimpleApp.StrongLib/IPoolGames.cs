using System.Reflection;

[assembly: AssemblyKeyFileAttribute("keyfile.snk")]

namespace SimpleApp.StrongLib;

internal interface IPoolGames
{
	public string Marco();
}
