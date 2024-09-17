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
		var expected = "Dummy";

		var dummyHelper = Substitute.For<IDummyHelper>();
		dummyHelper.GetDummyString().Returns(expected);

		var dummy = new Dummy(dummyHelper);
		Assert.Equal(expected, dummy.GetDummyString());
	}
}
