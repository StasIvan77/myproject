﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    class MyPictureBox : PictureBox
    {
        int index = 0;
        int imageIndex = 0;

        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public bool isMatch()
        {
            return (index == imageIndex);
        }

    }
}
