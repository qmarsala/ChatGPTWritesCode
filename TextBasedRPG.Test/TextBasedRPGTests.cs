namespace TextBasedRPG.Test;

public class TextBasedRPGTests
{
    [Fact]
    public void ExecuteCommand_ShouldExecuteCommand_WhenInputIsValid()
    {
        // Arrange
        var player = new Player();
        var game = new TextBasedRPG(player);
        var input = "fish";

        // Act
        game.ExecuteCommand(input);

        // Assert
        // We can't directly test the effect of the command on the player here,
        // so we just check that the command was executed without throwing an exception.
    }
    
    [Theory]
    [InlineData("invalid command")]
    [InlineData("")]
    [InlineData(null)]
    public void ExecuteCommand_ShouldThrowException_WhenInputIsInvalid(string input)
    {
        // Arrange
        var player = new Player();
        var game = new TextBasedRPG(player);

        // Act and Assert
        Assert.Throws<ArgumentException>(() => game.ExecuteCommand(input));
    }
}