using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Players;
using static HoakToe.GameResult;

namespace HoakToe.Game;

public class Game
{
    private readonly IDisplay display;
    private readonly Board board;
    private readonly IPlayer player1;
    private readonly IPlayer player2;

    public IPlayer currentPlayer { get; private set; }

    public Game(IDisplay display, IPlayer player1, IPlayer player2)
    {
        board = new Board(display);

        this.player1 = player1;
        this.player2 = player2;

        currentPlayer = this.player1;
        this.display = display;
    }

    public async Task<GameResult.Values> Play()
    {
        board.DisplayGameBoard();

        while (true)
        {
            Result<PlayerMove> playerMoves = await currentPlayer.GetNextMove();
            if (playerMoves.IsFailure)
            {
                display.WriteLine(playerMoves.Error);
                continue;
            }

            bool movePlayedSuccessfully = board.PlayMoveOnBoard(playerMoves.Value, currentPlayer.Icon);
            if (movePlayedSuccessfully is false)
            {
                display.WriteLine("Invalid move");
                continue;
            }
            board.DisplayGameBoard();

            GameResult.Values gameResult = board.IsGameOver(currentPlayer);
            if (gameResult == GameResult.Values.Draw || gameResult == GameResult.Values.Win)
            {
                display.WriteLine(GameResult.getEndGameMessage());
                break;
            }

            SwitchPlayer();
        }
        return GameResult.gameState;
    }

    private void SwitchPlayer()
    {
        if (currentPlayer == player1)
            currentPlayer = player2;
        else
            currentPlayer = player1;
    }

}
