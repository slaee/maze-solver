using MazeSolver.Utility;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MazeSolver.UserInterface
{
    public partial class MazeUI : Form
    {
        MazeProblemSolver m_Maze;
        
        private int[,] _mazeBoard;
        private int _mazeSize = 20;
        private int _mazeRowDimensions = 16;
        private int _mazeColDimensions = 20;

        private int _selectedX;
        private int _selectedY;

        public MazeUI()
        {
            InitializeComponent();
        }

        private void OnLoadMazeUI(object sender, EventArgs e)
        {
            this.m_Maze = new MazeProblemSolver(this._mazeRowDimensions, this._mazeColDimensions);
            this._mazeContainer.Size = new Size(this._mazeColDimensions * this._mazeSize + 3, this._mazeRowDimensions * this._mazeSize + 3);
            this._mazeBoard = this.m_Maze.GetMaze;
            this._labelPath.Visible = false;
            this._labelPathCaption.Visible = false;
        }

        private void OnPaintMazeContainer(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int index1 = 0; index1 < this._mazeRowDimensions; ++index1)
            {
                for (int index2 = 0; index2 < this._mazeColDimensions; ++index2)
                {     
                    graphics.DrawRectangle(
                        new Pen(Color.Black), 
                        (index2 * this._mazeSize), 
                        (index1 * this._mazeSize), 
                        this._mazeSize, 
                        this._mazeSize
                    );
                    if (this._mazeBoard[index1, index2] == 1)
                    {
                        graphics.FillRectangle(
                            (Brush)new SolidBrush(Color.Black),
                            (index2 * this._mazeSize + 1),
                            (index1 * this._mazeSize + 1),
                            (this._mazeSize - 1),
                            (this._mazeSize - 1)
                        );
                    }    
                        
                    if (this._mazeBoard[index1, index2] == 100)
                    {
                        graphics.FillRectangle(
                            (Brush)new SolidBrush(ColorTranslator.FromHtml("#04ff00")),
                            (index2 * this._mazeSize + 1),
                            (index1 * this._mazeSize + 1),
                            (this._mazeSize - 1),
                            (this._mazeSize - 1)
                        );
                    }
                }
            }
            
            graphics.FillEllipse(
                (Brush)new SolidBrush(Color.DarkCyan), 
                (this._selectedX * this._mazeSize + 5), 
                (this._selectedY * this._mazeSize + 5), 
                (this._mazeSize - 10), 
                (this._mazeSize - 10)
            );
        }

        private void OnMouseDownMazeContainer(object sender, MouseEventArgs e)
        {
            int index1 = e.X / this._mazeSize;
            int index2 = e.Y / this._mazeSize;

            if ((index1 >= this._mazeColDimensions) || (index1 < 0) || (index2 >= this._mazeRowDimensions) || (index2 < 0))
                return;

            if (this._drawWallsRadioButton.Checked)
            {
                this._mazeBoard = this.m_Maze.GetMaze;
                this._mazeBoard[index2, index1] = this._mazeBoard[index2, index1] != 0 ? 0 : 1;
                this.Refresh();
            }
            else if (this._mazeBoard[index2, index1] == 100)
            {
                while (this._selectedX != index1 || this._selectedY != index2)
                {
                    this._mazeBoard[this._selectedY, this._selectedX] = 0;
                    if ((this._selectedX - 1 >= 0) 
                        && (this._selectedX - 1 < this._mazeColDimensions) 
                        && (this._mazeBoard[this._selectedY, this._selectedX - 1] == 100))
                    {
                        --this._selectedX;
                    }
                    else if ((this._selectedX + 1 >= 0) 
                        && (this._selectedX + 1 < this._mazeColDimensions) 
                        && (this._mazeBoard[this._selectedY, this._selectedX + 1] == 100))
                    {
                        ++this._selectedX;
                    }
                    else if ((this._selectedY - 1 >= 0) 
                        && (this._selectedY - 1 < this._mazeRowDimensions) 
                        && (this._mazeBoard[this._selectedY - 1, this._selectedX] == 100))
                    {
                        --this._selectedY;
                    }
                    else if ((this._selectedY + 1 >= 0)
                        && (this._selectedY + 1 < this._mazeRowDimensions) 
                        && (this._mazeBoard[this._selectedY + 1, this._selectedX] == 100))
                    {
                        ++this._selectedY;
                    }
                    else if ((this._selectedY + 1 >= 0) && 
                        (this._selectedY + 1 < this._mazeRowDimensions) && 
                        (this._selectedX + 1 >= 0) && 
                        (this._selectedX + 1 < this._mazeColDimensions) && 
                        (this._mazeBoard[this._selectedY + 1, this._selectedX + 1] == 100))
                    {
                        ++this._selectedX;
                        ++this._selectedY;
                    }
                    else if ((this._selectedY - 1 >= 0) 
                        && (this._selectedY - 1 < this._mazeRowDimensions) 
                        && (this._selectedX + 1 >= 0) 
                        && (this._selectedX + 1 < this._mazeColDimensions)
                        && (this._mazeBoard[this._selectedY - 1, this._selectedX + 1] == 100))
                    {
                        ++this._selectedX;
                        --this._selectedY;
                    }
                    else if ((this._selectedY + 1 >= 0)
                        && (this._selectedY + 1 < this._mazeRowDimensions)
                        && (this._selectedX - 1 >= 0)
                        && (this._selectedX - 1 < this._mazeColDimensions)
                        && (this._mazeBoard[this._selectedY + 1, this._selectedX - 1] == 100))
                    {
                        --this._selectedX;
                        ++this._selectedY;
                    }
                    else if ((this._selectedY - 1 >= 0)
                        && (this._selectedY - 1 < this._mazeRowDimensions)
                        && (this._selectedX - 1 >= 0)
                        && (this._selectedX - 1 < this._mazeColDimensions)
                        && (this._mazeBoard[this._selectedY - 1, this._selectedX - 1] == 100))
                    {
                        --this._selectedX;
                        --this._selectedY;
                    }
                    
                    this.Refresh();
                }
            }
        }

        private void OnMouseMoveMazeContainer(object sender, MouseEventArgs e)
        {
            int toY = e.Y / this._mazeSize;
            int toX = e.X / this._mazeSize;
            if (toX >= this._mazeColDimensions || toX < 0 || toY >= this._mazeRowDimensions || toY < 0)
                return;
            
            this._mazeBoard = this.m_Maze.GetMaze;
            if (!this._drawWallsRadioButton.Checked)
            {
                int[,] path = this.m_Maze.FindPath(this._selectedY, this._selectedX, toY, toX);
                if (path != null)
                {
                    this._mazeBoard = path;
                    this._labelPath.Text = $"{(object)this._selectedY},{(object)this._selectedX} to {(object)toY},{(object)toX}";
                }
                else
                    this._labelPath.Text = "No Path Found";
                
                this.Refresh();
            }
        }

        private void OnCheckChangedDrawWall(object sender, EventArgs e)
        {
            this._mazeBoard = this.m_Maze.GetMaze;
            this._labelPath.Visible = false;
            this._labelPathCaption.Visible = false;
            this.Refresh();
        }

        private void OnClickGenerateMazeWalls(object sender, EventArgs e)
        {
            this._mazeBoard = this.m_Maze.GetMaze;
            this.m_Maze.AllowDiagonals = this._allowDiagonalCheckBox.Checked;
            this._labelPath.Visible = true;
            this._labelPathCaption.Visible = true;
            Random xRnd = new Random();
            Random yRnd = new Random();

            for (int index = 0; index < this._mazeRowDimensions * this._mazeColDimensions; ++index)
            {
                this._mazeBoard[xRnd.Next(0, this._mazeRowDimensions), yRnd.Next(0, this._mazeColDimensions)] = xRnd.Next(0, 2);
            }
            this._mazeBoard[this._selectedX, this._selectedY] = 0;
            this.Refresh();
        }

        private void OnCheckChangedFind(object sender, EventArgs e)
        {
            this.m_Maze.AllowDiagonals = this._allowDiagonalCheckBox.Checked;
            this._labelPath.Visible = true;
            this._labelPathCaption.Visible = true;
        }

        private void OnClickResetButton(object sender, EventArgs e)
        {
            this.m_Maze = new MazeProblemSolver(this._mazeRowDimensions, this._mazeColDimensions);
            this.m_Maze.AllowDiagonals = this._allowDiagonalCheckBox.Checked;
            this._mazeBoard = this.m_Maze.GetMaze;
            this.Refresh();
        }

        private void OnClickAboutButton(object sender, EventArgs e)
        {
            int num = (int)MessageBox.Show("Maze Problem Solver using");
        }

        private void OnClickExitButton(object sender, EventArgs e) => this.Close();

        private void OnCheckChangedAllowDiagonal(object sender, EventArgs e) => this.m_Maze.AllowDiagonals = this._allowDiagonalCheckBox.Checked;
    }
}
