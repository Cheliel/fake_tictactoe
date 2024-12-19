using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Players;

namespace HoakToe
{
    public class GameResult
    {
        
        public enum Values
        {
            Draw = 0,
            Playing = 1,
            Win = 2,
        }

        public static IPlayer? Winner;

        public static GameResult.Values gameState;

        public GameResult()
        {

        }



        public static string getEndGameMessage() 
        { 
            if(gameState == GameResult.Values.Draw)
            {
                return getDrawMessage();
            }
            else if (gameState == GameResult.Values.Win)
            {
                return getWinMessage(Winner);
            }
            else
            {
                return "";
            }
        }



        public static GameResult.Values Win(IPlayer player)
        {
            Winner = player;
            gameState = GameResult.Values.Win;
            return GetWin();
        }

        public static GameResult.Values Draw()
        {
            GameResult.gameState = GameResult.Values.Draw;
            return GetDraw();
        }


        public static GameResult.Values Playing()
        {
            GameResult.gameState = GameResult.Values.Playing;
            return GetPlaying();
        }

        public static GameResult.Values GetGameState()
        {
            return GameResult.gameState;
        }
        



        private static GameResult.Values GetDraw()
        {
            return GameResult.Values.Draw;
        }

        private static GameResult.Values GetPlaying()
        {
            return GameResult.Values.Playing;
        }
        private static GameResult.Values GetWin()
        {
            return GameResult.Values.Win;
        }



        private static string getDrawMessage()
        {
            return "It's a draw!";
        }

        private static string getWinMessage(IPlayer currenplayer)
        {
            return $"Player {currenplayer} has won the game!";
        }


    }
}
