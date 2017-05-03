using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    class GameBoard
    {
        
        int Width;
        int Heigth;

        Image originalImage = null; // image
        PictureBox originalImageContainer = null; // picBoxWhole

        Image[] imagePieces = null; // images
        PictureBox[] imagePieceContainers = null; // imagePieceContainers
        public Button mybutton;
        public GroupBox groupboxpuzzle; 

    public void SetImage() //playlevel() old
       {
            int numRow = (int)Math.Sqrt((int)GameLevel.Beginner);
            int numCol = numRow;
            
            int unitX = Width / numRow;
            int unitY = Heigth / numCol;
            
            int[] indice = new int[(int)GameLevel.Beginner]; // indexes of parts of splited image 

           PuzzleGame.myForm.groupboxPuzzleGetControl(groupboxpuzzle);            
            PuzzleGame.myForm.clickonbutton(mybutton);

            for (int i = 0; i < (int)GameLevel.Beginner; i++)
            {
                indice[i] = i;
                if (imagePieceContainers[i] == null)
                {
                    imagePieceContainers[i] = new MyPictureBox();
                   // imagePieceContainers[i].Click += new EventHandler(); // must be on puzzle click
                    imagePieceContainers[i].BorderStyle = BorderStyle.Fixed3D;
                }
                imagePieceContainers[i].Width = unitX;
                imagePieceContainers[i].Height = unitY;

                ((MyPictureBox)imagePieceContainers[i]).Index = i; //getting index of box

                CreateBitmapImage(originalImage, imagePieces, i, numRow, numCol, unitX, unitY); //dive to small images 
                imagePieceContainers[i].Location = new Point(unitX * (i % numCol), unitY * (i / numCol));
                if (!groupboxpuzzle.Controls.Contains(imagePieceContainers[i]))
                    groupboxpuzzle.Controls.Add(imagePieceContainers[i]); //setting location on created images
            }
        }

        private Bitmap CreateBitmapImage(Image image) //resizing input image for full groupboxPuzzle preview
        {
            Bitmap objBmpImage = new Bitmap(groupboxpuzzle.Width, groupboxpuzzle.Height);
            Graphics objGraphics = Graphics.FromImage(objBmpImage);
            objGraphics.Clear(Color.White);
            objGraphics.DrawImage(image, new Rectangle(0, 0, groupboxpuzzle.Width, groupboxpuzzle.Height));
            objGraphics.Flush();
            return objBmpImage;
        }
        private void CreateBitmapImage(Image originalImage, Image[] imagePieces, int index, int numRow, int numCol, int unitX, int unitY)//creating bitmap image preview for future  boxing
        {
            imagePieces[index] = new Bitmap(unitX, unitY);
            Graphics objGraphics = Graphics.FromImage(imagePieces[index]);
            objGraphics.Clear(Color.White);

            objGraphics.DrawImage(originalImage, new Rectangle(0, 0, unitX, unitY),
                new Rectangle(unitX * (index % numCol), unitY * (index / numCol), unitX, unitY),
                GraphicsUnit.Pixel);
            objGraphics.Flush();
        } 
        // void RemoveImage();

        // void SetupGrid(Puzzle puzzle);
    }
}

