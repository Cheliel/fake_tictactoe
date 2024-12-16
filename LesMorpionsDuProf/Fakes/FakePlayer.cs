using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LesMorpionsDuProf
{
    class FakePlayer : IPlayer
    {
        char IPlayer.icon => _icon;
        private readonly char _icon;
        private int nbTurn = 0;

        List<PlayerMoves> _moves = new List<PlayerMoves>();

        public FakePlayer(char icon, bool isLoser)
        {
            this._icon = icon;
            if(isLoser)
            {
                addLoserMoves();
            }
            else
            {
                addWinnerMoves();
            }

        }

        public Result<PlayerMoves> GetNextMove()
        {
            Console.WriteLine($"Player {_icon} - Enter row (1-3) and column (1-3), separated by a space");
            PlayerMoves currentMove = _moves.Union(_moves).ElementAt(nbTurn);

            if (int.TryParse(currentMove.Row.ToString(), out int targetRow) is false ||
                targetRow < 1 || targetRow > 3)
            {
                return Result.Failure<PlayerMoves>("Invalid target cell row must be betwen 1 and 3");
            }

            if (int.TryParse(currentMove.Column.ToString(), out int targetColumn) is false ||
                targetColumn < 1 || targetColumn > 3)
            {
                return Result.Failure<PlayerMoves>("Invalid target cell column must be betwen 1 and 3");
            }
            this.nbTurn ++;
            return Result.Success(currentMove);
        }

        public void addWinnerMoves()
        {
            _moves.Add(new PlayerMoves(1, 1));
            _moves.Add(new PlayerMoves(1, 2));
            _moves.Add(new PlayerMoves(1, 3));
        }
        public void addLoserMoves()
        {
            _moves.Add(new PlayerMoves(3, 3));
            _moves.Add(new PlayerMoves(2, 1));
            _moves.Add(new PlayerMoves(3, 1));
        }

    }
}
