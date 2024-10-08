using NSubstitute;

using Xunit;

namespace SimpleApp.StrongLib.Tests;

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
		var sut = Substitute.For<StrongLib.IPoolGames>();
		sut.Marco().Returns("Polo");
		
		// Act
		var result = sut.Marco();
		
		// Assert
		Assert.Equal("Polo", result);
	}
}
