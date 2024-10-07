using DeviceRunners.XHarness;

using Microsoft.Extensions.Logging;

using Sentry.Tests;

namespace SimpleApp.DeviceTests;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseXHarnessTestRunner(conf => conf
				.AddTestAssembly(typeof(MauiProgram).Assembly)
				.AddTestAssembly(typeof(SentrySdkTests).Assembly)
				.AddXunit());

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
