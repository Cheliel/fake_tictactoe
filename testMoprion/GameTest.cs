using FluentAssertions;
using HoakToe;
using HoakToe.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;
using TicTacToe.Display;
using TicTacToe.Players;

namespace testMoprion
{
    public class GameTest
    {
        [Fact]
        public void GameWin()
        {
            System.Diagnostics.Debug.WriteLine("GameWin");
            //arrange
            IDisplay display = new DebugDisplay();
            FakePlayer player = new FakePlayer(PlayerConstants.PlayerOneIcon, "1 1,1 2,1 3");
            FakePlayer player2 = new FakePlayer(PlayerConstants.PlayerTwoIcon, "3 3,2 1,1 3");
            Game game = new Game(display, player, player2);


            //Act 
            GameResult.Values gameResult = game.Play();

            //Assert
            gameResult.Should().Be(GameResult.Values.Win);
        

        }

        [Fact]
        public void GameDraw()
        {
            //arrange
            IDisplay display = new DebugDisplay();
            IPlayer player = new FakePlayer(PlayerConstants.PlayerOneIcon, "2 2,3 1,1 2,1 2,1 3");
            IPlayer player2 = new FakePlayer(PlayerConstants.PlayerTwoIcon, "1 3,1 1,2 3,3 2, 1 1");
            Game game = new Game(display, player, player2);

            //Act 
            GameResult.Values gameResult = game.Play();

            //Assert
            gameResult.Should().Be(GameResult.Values.Draw);
        }

    }
}