using Microsoft.Extensions.Logging;
using DeviceRunners.UITesting;
using DeviceRunners.XHarness;

namespace DeviceTestingKitApp.DeviceTests;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.ConfigureUITesting()
			.UseXHarnessTestRunner(conf => conf
				.AddTestAssembly(typeof(MauiProgram).Assembly)
				.AddXunit());

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
