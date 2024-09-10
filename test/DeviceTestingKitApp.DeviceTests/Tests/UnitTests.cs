using NSubstitute;

namespace DeviceTestingKitApp.DeviceTests.Tests;

public class UnitTests
{
	[Fact]
	public void SuccessfulTest()
	{
		Assert.True(true);
	}

	[Fact]
	public void InternalInterfaces_ShouldBeAccessible()
	{
		var dummyHelper = Substitute.For<IDummyHelper>();
		var dummy = new Dummy(dummyHelper);
		Assert.Equal("Dummy", dummy.GetDummyString());
	}		
}
