using System;
using System.Collections.Generic;
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

        public void GameSucess()
        {
            //arrange
            IDisplay display = new ConsoleDisplay();
            IPlayer player = new RandomPlayer('X');
            IPlayer player2 = new RandomPlayer('O');
            Game game = new Game(display, player, player2);
            game.Play();
        }
}
