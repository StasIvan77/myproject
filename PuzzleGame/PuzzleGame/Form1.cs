using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class PuzzleGame : Form
    {
        public static PuzzleGame myForm ;
        public PuzzleGame()
        {
            InitializeComponent();
            myForm = this;
        }

        OpenFileDialog openFileDialog = null; //for image open
        Image image; // browsed image
        PictureBox picBoxWhole = null; //using for full image show without crop

        PictureBox[] picBoxes = null; //for PARTitioning
        Image[] images = null; // for having parts of image in memory

        const int LEVEL_1_NUM = 4; //using for numerous of squares 
        const int LEVEL_2_NUM = 9;
        const int LEVEL_3_NUM = 16;
        const int LEVEL_4_NUM = 25;

        int currentLevel = 0;
        int previousLevel = 0;
        int attemps = 0;

        MyPictureBox firstBox = null; //for swaping
        MyPictureBox secondBox = null;

        public void getStatusLabel(string textchange)
        {
            labelStatus.Text = textchange;                   
        }

        public GroupBox groupboxPuzzleGetControl(GroupBox myGroupBox)
        {
            myGroupBox = groupboxPuzzle;
            return myGroupBox;
        }

        public Button clickonbutton(Button b)
        {
            this.buttonLevel1.Click += new System.EventHandler(Puzzle.buttonLevel1afterClick);
            b = buttonLevel1;
            return b;
        }



        private void buttonImageBrowse_Click(object sender, EventArgs e) //getting image in OpenFileDialog
        {

            if (openFileDialog == null)
                openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RemoveOldImageFromBoard();
               
                textboxImagePath.Text = openFileDialog.FileName;
                try
                {
                    image = CreateBitmapImage(Image.FromFile(openFileDialog.FileName));
                }
                catch
                {
                    MessageBox.Show("Choose pls image format");
                    buttonImageBrowse_Click(sender, e);
                }
                if (picBoxWhole == null)
                {
                    picBoxWhole = new PictureBox();
                    picBoxWhole.Height = groupboxPuzzle.Height;
                    picBoxWhole.Width = groupboxPuzzle.Width;
                    groupboxPuzzle.Controls.Add(picBoxWhole);
                }
                labelStatus.Text = "Pls choose\n level...\n";
                picBoxWhole.Image = image;
                groupboxPlayMode.Visible = true;
                groupboxPuzzle.Visible = true;
                groupboxStatus.Visible = true;
                buttonComputerTry.Visible = true;
            }
        }

        private void PlayLevel()
        {
            RemoveOldImageFromBoard();

            if (picBoxes == null)
            {
                images = new Image[currentLevel];
                picBoxes = new PictureBox[currentLevel];
            }

            int numRow = (int)Math.Sqrt(currentLevel);
            int numCol = numRow;
            int unitX = groupboxPuzzle.Width / numRow;
            int unitY = groupboxPuzzle.Height / numCol;
            int[] indice = new int[currentLevel]; // indexes of parts of splited image 

            for (int i = 0; i < currentLevel; i++)
            {
                indice[i] = i;
                if (picBoxes[i] == null)
                {
                    picBoxes[i] = new MyPictureBox();
                    picBoxes[i].Click += new EventHandler(OnPuzzleClick);
                    picBoxes[i].BorderStyle = BorderStyle.Fixed3D;
                }
                picBoxes[i].Width = unitX;
                picBoxes[i].Height = unitY;

                ((MyPictureBox)picBoxes[i]).Index = i; //getting index of box

                CreateBitmapImage(image, images, i, numRow, numCol, unitX, unitY); //dive to small images 
                picBoxes[i].Location = new Point(unitX * (i % numCol), unitY * (i / numCol));
                if (!groupboxPuzzle.Controls.Contains(picBoxes[i]))
                    groupboxPuzzle.Controls.Add(picBoxes[i]); //setting location on created images
            }
            shuffle(ref indice); //
            for (int i = 0; i < currentLevel; i++) //setting images on position we see after shuffling
            {
                picBoxes[i].Image = images[indice[i]];
                ((MyPictureBox)picBoxes[i]).ImageIndex = indice[i];
            }
            previousLevel = currentLevel;//for checkup deleted image after end round
        }

        private void RemoveOldImageFromBoard()
        {
            if (picBoxWhole != null) //delete image before chosing another one
            {
                groupboxPuzzle.Controls.Remove(picBoxWhole);
                picBoxWhole.Dispose();
                picBoxWhole = null;
            }
            if (picBoxes != null)//delete boxes with images before chosing another one image 
            {
                for (int i = 0; i < previousLevel; i++)
                {
                    picBoxes[i].Dispose();
                }
                picBoxes = null;
            }
        }

        private Bitmap CreateBitmapImage(Image image) //resizing input image for full groupboxPuzzle preview
        {
            Bitmap objBmpImage = new Bitmap(groupboxPuzzle.Width, groupboxPuzzle.Height);
            Graphics objGraphics = Graphics.FromImage(objBmpImage);
            objGraphics.Clear(Color.White);
            objGraphics.DrawImage(image, new Rectangle(0, 0, groupboxPuzzle.Width, groupboxPuzzle.Height));
            objGraphics.Flush();
            return objBmpImage;
        }

        private void CreateBitmapImage(Image image, Image[] images, int index, int numRow, int numCol, int unitX, int unitY)//creating bitmap image preview for future  boxing
        {
            images[index] = new Bitmap(unitX, unitY);
            Graphics objGraphics = Graphics.FromImage(images[index]);
            objGraphics.Clear(Color.White);

            objGraphics.DrawImage(image, new Rectangle(0, 0, unitX, unitY),
                new Rectangle(unitX * (index % numCol), unitY * (index / numCol), unitX, unitY),
                GraphicsUnit.Pixel);
            objGraphics.Flush();
        }

        private void shuffle(ref int[] array) //shuffles input int array , in our example = images
        {
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n);
                n--;
                int temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        private void SwitchImages(MyPictureBox box1, MyPictureBox box2) //replaces 2 boxs and checks for finish
        {
            int tmp = box2.ImageIndex;
            box2.Image = images[box1.ImageIndex];
            box2.ImageIndex = box1.ImageIndex;
            box1.Image = images[tmp];
            box1.ImageIndex = tmp;
            attemps++;
            if (isSuccessful())
            {
                MessageBox.Show("It tooks " + attemps + " swaps");
                labelStatus.Text = "Well done!";
                attemps = 0;
            }
        }

        private bool isSuccessful()
        {
            for (int i = 0; i < currentLevel; i++)
            {
                if (((MyPictureBox)picBoxes[i]).ImageIndex != ((MyPictureBox)picBoxes[i]).Index)
                    return false;
            }
            return true;
        }

       private void buttonLevel1_Click(object sender, EventArgs e)
        {
            currentLevel = LEVEL_1_NUM;
            labelStatus.Text = "Level 1\n  in process...";
            PlayLevel();
        }
       
        private void buttonLevel2_Click(object sender, EventArgs e)
        {
            currentLevel = LEVEL_2_NUM;
            labelStatus.Text = "Level 2\n  in process...";
            PlayLevel();
        }

        private void buttonLevel3_Click(object sender, EventArgs e)
        {
            currentLevel = LEVEL_3_NUM;
            labelStatus.Text = "Level 3\n  in process...";
            PlayLevel();
        }

        private void buttonLevel4_Click(object sender, EventArgs e)
        {
            currentLevel = LEVEL_4_NUM;
            labelStatus.Text = "Level 4\n  in process...";
            PlayLevel();
        }

        public void OnPuzzleClick(object sender, EventArgs e)
        {
            if (firstBox == null)
            {
                firstBox = (MyPictureBox)sender;
                ((MyPictureBox)sender).BorderStyle = BorderStyle.FixedSingle;
            }
            else if (secondBox == null)
            {
                secondBox = (MyPictureBox)sender;
                firstBox.BorderStyle = BorderStyle.Fixed3D;
                secondBox.BorderStyle = BorderStyle.Fixed3D;
                SwitchImages(firstBox, secondBox);
                firstBox = null;
                secondBox = null;
            }

        }

        private void buttonComputerTry_Click(object sender, EventArgs e)
        {
            int[] array = new int[currentLevel];
            Random rng = new Random();
            int n = array.Length;
            while (isSuccessful() == false)
            {
                OnPuzzleClick(picBoxes[rng.Next(n)], e);

            }
        }

       
    }
}
