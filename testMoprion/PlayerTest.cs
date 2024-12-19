using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

using TicTacToe;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace testMoprion
{
    public class PlayerTest
    {
        [Fact]
        public void Move()
        {
            //arrange
            IPlayer player1 = new RandomPlayer('X');

            //act
            Result<PlayerMove> activeMove = player1.GetNextMove();

            //assert
            Assert.InRange(activeMove.Value.Row, 1, 3);
            activeMove.Value.Column.Should().BeInRange(1, 3);

        }

    }
}
