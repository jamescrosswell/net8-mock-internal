using NSubstitute;

using SimpleApp.StrongLib;

namespace SimpleApp.DeviceTests.Tests;

public class StrongLibTests
{
	[Fact]
	public void SuccessfulTest()
	{
		Assert.True(true);
	}

	[Fact]
	public void InternalInterfaces_ShouldBeAccessible()
	{
		// Arrange
		var sut = Substitute.For<IPoolGames>();
		sut.Marco().Returns("Polo");
		
		// Act
		var result = sut.Marco();
		
		// Assert
		Assert.Equal("Polo", result);
	}
}
