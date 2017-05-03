using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PuzzleGame.PuzzleGame;

namespace PuzzleGame
{
    class Puzzle
    {
        static void CurrentFunc()
        {
            var someClass = new Puzzle();
            // someClass.buttonLevel1afterClick();
            
        }

        public static int currentLevel= 0;
        //GameLevel level;
        //  private EventHandler buttonLevel1;
        void Shuffle(int[] pieces)
        {

        }
        public static int ChangeLevel(int a )
        {
            currentLevel += a ;
            return currentLevel;
        }
        public static void SetLevel(GameLevel level)
        {
            // ChangeLevel(currentLevel, (int)level);
           ChangeLevel((int)level);
            //    GameBoard.SetImage();

        }


        public static void buttonLevel1afterClick(object sender, EventArgs e)
        {
            currentLevel = 0;
            PuzzleGame.myForm.getStatusLabel("Level 1\n  in process...\n");
            SetLevel(GameLevel.Beginner);
        }
        /*internal static  void labelStatusChange(object sender, EventArgs e)
        {
            if (PuzzleGame.myForm != null)
                PuzzleGame.myForm.getStatusLabel("new value");
        }*/

    }
}
