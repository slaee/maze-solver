﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MazeSolver.UserInterface
{
    partial class MazeUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text = "Maze Solver";
            this.components = new Container();
            this.AutoScaleBaseSize = new Size(5, 13);
            this.ClientSize = new Size(608, 381);
        }

        #endregion

    }
}