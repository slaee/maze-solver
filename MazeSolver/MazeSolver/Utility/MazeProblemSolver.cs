using System;

namespace MazeSolver.Utility
{
    public class MazeProblemSolver
    {
        private int[,] _mazeBoard;
        private int _mazeRows;
        private int _mazeCols;
        private int _path = 100;
        private bool _isDiagonalAllowed = false;

        public event MazeChangedHandler OnMazeChangedEvent;

        public MazeProblemSolver(int[,] mazeBoard)
        {
            this._mazeBoard = mazeBoard;
            this._mazeRows = mazeBoard.GetLength(0);
            this._mazeCols = mazeBoard.GetLength(1);
        }

        public MazeProblemSolver(int mazeRows, int mazeCols)
        {
            this._mazeBoard = new int[mazeRows, mazeCols];
            this._mazeRows = mazeRows;
            this._mazeCols = mazeCols;
        }

        public int Rows => this._mazeRows;

        public int Cols => this._mazeCols;

        public int[,] GetMaze => this._mazeBoard;

        public int PathCharacter
        {
            get => this._path;
            set => this._path = value != 0 ? value : throw new Exception("Invalid path character specified");
        }

        public bool AllowDiagonals
        {
            get => this._isDiagonalAllowed;
            set => this._isDiagonalAllowed = value;
        }

        public int this[int rows, int cols]
        {
            get => this._mazeBoard[rows, cols];
            set
            {
                this._mazeBoard[rows, cols] = value;
                if (this.OnMazeChangedEvent == null)
                    return;
                this.OnMazeChangedEvent(rows, cols);
            }
        }

        private int GetNodeContents(int[,] mazeBoard, int nodeNumber)
        {
            int length = mazeBoard.GetLength(1);
            return mazeBoard[nodeNumber / length, nodeNumber - nodeNumber / length * length];
        }

        private void ChangeNodeContents(int[,] mazeBoard, int nodeNumber, int newVal)
        {
            int length = mazeBoard.GetLength(1);
            mazeBoard[nodeNumber / length, nodeNumber - nodeNumber / length * length] = newVal;
        }

        public int[,] FindPath(int fromY, int fromX, int toY, int toX) => this.Search(fromY * this.Cols + fromX, toY * this.Cols + toX);

        private int[,] Search(int start, int end)
        {
            int iRows = this._mazeRows;
            int iCols = this._mazeCols;

            int length = iRows * iCols;
            
            int[] numArray1 = new int[length];
            int[] numArray2 = new int[length];
            
            int index1 = 0;
            int index2 = 0;
            
            if (this.GetNodeContents(this._mazeBoard, start) != 0 || this.GetNodeContents(this._mazeBoard, end) != 0)
                return (int[,])null;
            
            int[,] iMaze1 = new int[iRows, iCols];
            
            for (int index3 = 0; index3 < iRows; ++index3)
            {
                for (int index4 = 0; index4 < iCols; ++index4)
                    iMaze1[index3, index4] = 0;
            }
            
            numArray1[index2] = start;
            numArray2[index2] = -1;
            
            for (int index5 = index2 + 1; index1 != index5 && numArray1[index1] != end; ++index1)
            {
                int iNodeNo1 = numArray1[index1];
                int iNodeNo2 = iNodeNo1 - 1;
                if (iNodeNo2 >= 0 && iNodeNo2 / iCols == iNodeNo1 / iCols && this.GetNodeContents(this._mazeBoard, iNodeNo2) == 0 && this.GetNodeContents(iMaze1, iNodeNo2) == 0)
                {
                    numArray1[index5] = iNodeNo2;
                    numArray2[index5] = iNodeNo1;
                    this.ChangeNodeContents(iMaze1, iNodeNo2, 1);
                    ++index5;
                }
                int iNodeNo3 = iNodeNo1 + 1;
                if (iNodeNo3 < length && iNodeNo3 / iCols == iNodeNo1 / iCols && this.GetNodeContents(this._mazeBoard, iNodeNo3) == 0 && this.GetNodeContents(iMaze1, iNodeNo3) == 0)
                {
                    numArray1[index5] = iNodeNo3;
                    numArray2[index5] = iNodeNo1;
                    this.ChangeNodeContents(iMaze1, iNodeNo3, 1);
                    ++index5;
                }
                int iNodeNo4 = iNodeNo1 - iCols;
                if (iNodeNo4 >= 0 && this.GetNodeContents(this._mazeBoard, iNodeNo4) == 0 && this.GetNodeContents(iMaze1, iNodeNo4) == 0)
                {
                    numArray1[index5] = iNodeNo4;
                    numArray2[index5] = iNodeNo1;
                    this.ChangeNodeContents(iMaze1, iNodeNo4, 1);
                    ++index5;
                }
                int iNodeNo5 = iNodeNo1 + iCols;
                if (iNodeNo5 < length && this.GetNodeContents(this._mazeBoard, iNodeNo5) == 0 && this.GetNodeContents(iMaze1, iNodeNo5) == 0)
                {
                    numArray1[index5] = iNodeNo5;
                    numArray2[index5] = iNodeNo1;
                    this.ChangeNodeContents(iMaze1, iNodeNo5, 1);
                    ++index5;
                }
                if (this._isDiagonalAllowed)
                {
                    int iNodeNo6 = iNodeNo1 + iCols + 1;
                    if (iNodeNo6 < length && iNodeNo6 >= 0 && iNodeNo6 / iCols == iNodeNo1 / iCols + 1 && this.GetNodeContents(this._mazeBoard, iNodeNo6) == 0 && this.GetNodeContents(iMaze1, iNodeNo6) == 0)
                    {
                        numArray1[index5] = iNodeNo6;
                        numArray2[index5] = iNodeNo1;
                        this.ChangeNodeContents(iMaze1, iNodeNo6, 1);
                        ++index5;
                    }
                    int iNodeNo7 = iNodeNo1 - iCols + 1;
                    if (iNodeNo7 >= 0 && iNodeNo7 < length && iNodeNo7 / iCols == iNodeNo1 / iCols - 1 && this.GetNodeContents(this._mazeBoard, iNodeNo7) == 0 && this.GetNodeContents(iMaze1, iNodeNo7) == 0)
                    {
                        numArray1[index5] = iNodeNo7;
                        numArray2[index5] = iNodeNo1;
                        this.ChangeNodeContents(iMaze1, iNodeNo7, 1);
                        ++index5;
                    }
                    int iNodeNo8 = iNodeNo1 + iCols - 1;
                    if (iNodeNo8 < length && iNodeNo8 >= 0 && iNodeNo8 / iCols == iNodeNo1 / iCols + 1 && this.GetNodeContents(this._mazeBoard, iNodeNo8) == 0 && this.GetNodeContents(iMaze1, iNodeNo8) == 0)
                    {
                        numArray1[index5] = iNodeNo8;
                        numArray2[index5] = iNodeNo1;
                        this.ChangeNodeContents(iMaze1, iNodeNo8, 1);
                        ++index5;
                    }
                    int iNodeNo9 = iNodeNo1 - iCols - 1;
                    if (iNodeNo9 >= 0 && iNodeNo9 < length && iNodeNo9 / iCols == iNodeNo1 / iCols - 1 && this.GetNodeContents(this._mazeBoard, iNodeNo9) == 0 && this.GetNodeContents(iMaze1, iNodeNo9) == 0)
                    {
                        numArray1[index5] = iNodeNo9;
                        numArray2[index5] = iNodeNo1;
                        this.ChangeNodeContents(iMaze1, iNodeNo9, 1);
                        ++index5;
                    }
                }
                this.ChangeNodeContents(iMaze1, iNodeNo1, 2);
            }
            int[,] iMaze2 = new int[iRows, iCols];
            for (int index6 = 0; index6 < iRows; ++index6)
            {
                for (int index7 = 0; index7 < iCols; ++index7)
                    iMaze2[index6, index7] = this._mazeBoard[index6, index7];
            }
            int iNodeNo = end;
            this.ChangeNodeContents(iMaze2, iNodeNo, this._path);
            for (int index8 = index1; index8 >= 0; --index8)
            {
                if (numArray1[index8] == iNodeNo)
                {
                    iNodeNo = numArray2[index8];
                    if (iNodeNo == -1)
                        return iMaze2;
                    this.ChangeNodeContents(iMaze2, iNodeNo, this._path);
                }
            }
            return (int[,])null;
        }

        private enum Status
        {
            Ready,
            Waiting,
            Processed,
        }
    }
}
