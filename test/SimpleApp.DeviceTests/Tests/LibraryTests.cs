using NSubstitute;

using SimpleApp.Library;

namespace SimpleApp.DeviceTests.Tests;

public class LibraryTests
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
