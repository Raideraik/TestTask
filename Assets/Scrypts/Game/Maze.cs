using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
    public MazeGeneratorCell[,] Cells;
    public Vector2Int FinishPosition;
}

public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool Visited = false;
    public int DistanceFromStart;
}