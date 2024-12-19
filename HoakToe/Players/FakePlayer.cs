using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Players;
using TicTacToe.Boards;
using System.Diagnostics;



namespace TicTacToe
{
    public class FakePlayer : IPlayer
    {
        char IPlayer.Icon => _icon;
        private readonly char _icon;

        public Queue<PlayerMove> _moves = null;

        public FakePlayer(char icon, string moves)
        {
            System.Diagnostics.Debug.WriteLine(moves);
            this._icon = icon;
            _moves = new Queue<PlayerMove>(SplitMovesIntoArray(moves).Select(move => GetMoveFromString(move)));
        }

        public Queue<PlayerMove> getMoves()
        {
            return _moves;
        }

        public FakePlayer(char icon, bool isLoser)
        {
            this._icon = icon;
            if (isLoser)
            {
                addLoserMoves();
            }
            else
            {
                addWinnerMoves();
            }
        }

        private static String[] SplitMovesIntoArray(string moves)
        {
            return moves.Split(',');
        }
        
        private static PlayerMove GetMoveFromString(string move)
        {
            string[] splitedMove = move.Split(' ');
            PlayerMove d = new PlayerMove(int.Parse(splitedMove[0]), int.Parse(splitedMove[1]));
            System.Diagnostics.Debug.WriteLine(d.Row + " || " + d.Column);
            return d;
        }

        public Task<Result<PlayerMove>> GetNextMove()
        {
            Console.WriteLine($"Player {_icon} - Enter row (1-3) and column (1-3), separated by a space");
            PlayerMove currentMove = _moves.Dequeue();

            Result<PlayerMove> result;

            if (int.TryParse(currentMove.Row.ToString(), out int targetRow) is false ||
                targetRow < 1 || targetRow > 3)
            {
                result = Result.Failure<PlayerMove>("Invalid target cell row must be betwen 1 and 3");
            }

            if (int.TryParse(currentMove.Column.ToString(), out int targetColumn) is false ||
                targetColumn < 1 || targetColumn > 3)
            {
                result = Result.Failure<PlayerMove>("Invalid target cell column must be betwen 1 and 3");
            }
            result = Result.Success(currentMove);

            return Task.Run(() => result);
        }

        private void addWinnerMoves()
        {
            _moves.Append(new PlayerMove(1, 1));
            _moves.Append(new PlayerMove(1, 2));
            _moves.Append(new PlayerMove(1, 3));
        }
        public void addLoserMoves()
        {
            _moves.Append(new PlayerMove(3, 3));
            _moves.Append(new PlayerMove(2, 1));
            _moves.Append(new PlayerMove(3, 1));
        }

    }
}
