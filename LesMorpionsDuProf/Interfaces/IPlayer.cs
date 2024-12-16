using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace LesMorpionsDuProf
{
     interface IPlayer
    {
         public char icon { get;}

        Result<PlayerMoves> GetNextMove();
    }
}
