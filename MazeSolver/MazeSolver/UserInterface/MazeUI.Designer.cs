using System;
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
        private IContainer _componentContainer = null;
        private PictureBox _mazeContainer;
        private GroupBox _actionContainer;
        private CheckBox _allowDiagonalCheckBox;

        private Label _labelPath;
        private Label _labelPathCaption;

        private RadioButton _drawWallsRadioButton;
        private RadioButton _findPathRadioButton;

        private Button _generateWallsButton;
        private Button _resetButton;
        private Button _aboutButton;
        private Button _exitButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_componentContainer != null))
            {
                _componentContainer.Dispose();
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
            this._componentContainer = new Container();
            this.AutoScaleBaseSize = new Size(5, 13);
            this.ClientSize = new Size(608, 381);

            this._mazeContainer = new PictureBox();
            this._actionContainer = new GroupBox();
            this._allowDiagonalCheckBox = new CheckBox();

            this._labelPath = new Label();
            this._labelPathCaption = new Label();

            this._findPathRadioButton = new RadioButton();
            this._drawWallsRadioButton = new RadioButton();
            
            this._resetButton = new Button();
            this._aboutButton = new Button();
            this._exitButton = new Button();
            this._generateWallsButton = new Button();
            
            ((ISupportInitialize) this._mazeContainer).BeginInit();
            this._actionContainer.SuspendLayout();
            this.SuspendLayout();
            
            this._mazeContainer.BorderStyle = BorderStyle.FixedSingle;
            this._mazeContainer.Location = new Point(24, 16);
            this._mazeContainer.Name = "pictureBox1";
            this._mazeContainer.Size = new Size(403, 336);
            this._mazeContainer.TabIndex = 0;
            this._mazeContainer.TabStop = false;
            this._mazeContainer.MouseMove += new MouseEventHandler(this.OnMouseMoveMazeContainer);
            this._mazeContainer.MouseDown += new MouseEventHandler(this.OnMouseDownMazeContainer);
            this._mazeContainer.Paint += new PaintEventHandler(this.OnPaintMazeContainer);
            
            this._labelPath.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this._labelPath.Location = new Point(472, 208);
            this._labelPath.Name = "lblPath";
            this._labelPath.Size = new Size(128, 16);
            this._labelPath.TabIndex = 3;

            this._actionContainer.Name = "grpAction";
            this._actionContainer.Text = "Action";
            this._actionContainer.Location = new Point(472, 16);
            this._actionContainer.Size = new Size(120, 104);
            this._actionContainer.TabIndex = 4;
            this._actionContainer.TabStop = false;
            this._actionContainer.Controls.Add((Control) this._findPathRadioButton);
            this._actionContainer.Controls.Add((Control) this._drawWallsRadioButton);

            this._findPathRadioButton.Location = new Point(8, 64);
            this._findPathRadioButton.Name = "bFind";
            this._findPathRadioButton.Size = new Size(104, 24);
            this._findPathRadioButton.TabIndex = 1;
            this._findPathRadioButton.Text = "Find Path";
            this._findPathRadioButton.CheckedChanged += new EventHandler(this.OnCheckChangedFind);
            
            this._drawWallsRadioButton.Checked = true;
            this._drawWallsRadioButton.Location = new Point(8, 24);
            this._drawWallsRadioButton.Name = "bDraw";
            this._drawWallsRadioButton.Size = new Size(104, 24);
            this._drawWallsRadioButton.TabIndex = 0;
            this._drawWallsRadioButton.TabStop = true;
            this._drawWallsRadioButton.Text = "Draw Walls";
            this._drawWallsRadioButton.CheckedChanged += new EventHandler(this.OnCheckChangedDrawWall);
            
            this._labelPathCaption.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this._labelPathCaption.Location = new Point(472, 192);
            this._labelPathCaption.Name = "lblPathCaption";
            this._labelPathCaption.Size = new Size(100, 16);
            this._labelPathCaption.TabIndex = 5;
            this._labelPathCaption.Text = "Current Path";
            
            this._resetButton.Location = new Point(472, 248);
            this._resetButton.Name = "cmdReset";
            this._resetButton.Size = new Size(104, 24);
            this._resetButton.TabIndex = 6;
            this._resetButton.Text = "&Reset Maze";
            this._resetButton.Click += new EventHandler(this.OnClickResetButton);
            
            this._aboutButton.Location = new Point(472, 288);
            this._aboutButton.Name = "button1";
            this._aboutButton.Size = new Size(104, 24);
            this._aboutButton.TabIndex = 7;
            this._aboutButton.Text = "&About";
            this._aboutButton.Click += new EventHandler(this.OnClickAboutButton);
            
            this._exitButton.Location = new Point(472, 328);
            this._exitButton.Name = "cmdExit";
            this._exitButton.Size = new Size(104, 24);
            this._exitButton.TabIndex = 8;
            this._exitButton.Text = "E&xit";
            this._exitButton.Click += new EventHandler(this.OnClickExitButton);

            this._generateWallsButton.Location = new Point(472, 155);
            this._generateWallsButton.Name = "cmdGenerateWalls";
            this._generateWallsButton.Size = new Size(104, 24);
            this._generateWallsButton.TabIndex = 5;
            this._generateWallsButton.Text = "&Generate Walls";
            this._generateWallsButton.Click += new EventHandler(this.OnClickGenerateMazeWalls);

            this._allowDiagonalCheckBox.Location = new Point(480, 124);
            this._allowDiagonalCheckBox.Name = "chkDiagonal";
            this._allowDiagonalCheckBox.Size = new Size(112, 24);
            this._allowDiagonalCheckBox.TabIndex = 9;
            this._allowDiagonalCheckBox.Text = "Allow Diagonals";
            this._allowDiagonalCheckBox.CheckedChanged += new EventHandler(this.OnCheckChangedAllowDiagonal);
            
            this.Controls.Add((Control)this._allowDiagonalCheckBox);
            this.Controls.Add((Control)this._exitButton);
            this.Controls.Add((Control)this._aboutButton);
            this.Controls.Add((Control)this._resetButton);
            this.Controls.Add((Control)this._generateWallsButton);
            this.Controls.Add((Control)this._labelPathCaption);
            this.Controls.Add((Control)this._actionContainer);
            this.Controls.Add((Control)this._labelPath);
            this.Controls.Add((Control)this._mazeContainer);

            this.Load += new EventHandler(this.OnLoadMazeUI);
            ((ISupportInitialize)this._mazeContainer).EndInit();
            this._actionContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        
    }
}