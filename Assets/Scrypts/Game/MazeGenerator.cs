using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MazeGenerator
{
    public int Width = 10;
    public int Height = 10;

    public Maze GenerateMaze()
    {
        MazeGeneratorCell[,] cells = new MazeGeneratorCell[Width, Height];

        for (int X = 0; X < cells.GetLength(0); X++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[X, y] = new MazeGeneratorCell { X = X, Y = y };
            }
        }

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            cells[x, Height - 1].WallLeft = false;
        }

        for (int y = 0; y < cells.GetLength(1); y++)
        {
            cells[Width - 1, y].WallBottom = false;
        }

        RemoveWallsWithBackTracker(cells);

        Maze maze = new Maze();

        maze.Cells = cells;
        maze.FinishPosition = PlaceMazeExit(cells);


        return maze;
    }



    private void RemoveWallsWithBackTracker(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell current = maze[0, 0];
        current.Visited = true;
        current.DistanceFromStart = 0;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();

        do
        {
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited)
                unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited)
                unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < Width - 2 && !maze[x + 1, y].Visited)
                unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < Height - 2 && !maze[x, y + 1].Visited)
                unvisitedNeighbours.Add(maze[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                MazeGeneratorCell chosen = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);
                chosen.DistanceFromStart = current.DistanceFromStart+1;
                current = chosen;

            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y)
                a.WallBottom = false;
            else
                b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X)
                a.WallLeft = false;
            else
                b.WallLeft = false;
        }
    }
    
    private Vector2Int PlaceMazeExit(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell furthest = maze[0, 0];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, Height - 2].DistanceFromStart > furthest.DistanceFromStart)
                furthest = maze[x, Height - 2];
            if (maze[x, 0].DistanceFromStart > furthest.DistanceFromStart)
                furthest = maze[x, 0];

        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            if (maze[Width - 2, y].DistanceFromStart > furthest.DistanceFromStart)
                furthest = maze[Width - 2, y];

            if (maze[0, y].DistanceFromStart > furthest.DistanceFromStart)
                furthest = maze[0, y];
        }

        
        return new Vector2Int(furthest.X, furthest.Y);
       
    }

}
