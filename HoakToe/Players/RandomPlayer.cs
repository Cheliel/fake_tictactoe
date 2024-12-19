using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace TicTacToe;

public class RandomPlayer : Player
{
    public override char Icon { get; }

    public RandomPlayer(char icon)
    {
        this.Icon = icon;
    }

    public override async Task<Result<PlayerMove>> GetNextMove()
    {
        await Task.Delay(1000);
        return Result.Success(PlayerMove.Random);
    }
        //=> PlayerMove.Random;

}