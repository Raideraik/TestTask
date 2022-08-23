using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Vector3 _cellSize = new Vector3(1, 1, 0);
    [SerializeField] private Path _path;
    [SerializeField] private GameObject _container;

    private Maze _maze;
    private Cell _cell;
    private bool _createEnemy = false;

    public Vector3 CellSize => _cellSize;
    public Maze Maze => _maze;

    private void Awake()
    {
        MazeGenerator generator = new MazeGenerator();
        _maze = generator.GenerateMaze();

        for (int x = 0; x < _maze.Cells.GetLength(0); x++)
        {
            for (int y = 0; y < _maze.Cells.GetLength(1); y++)
            {

                Cell cell = Instantiate(_cellPrefab, new Vector3(x * _cellSize.x, y * _cellSize.y, y * _cellSize.z), Quaternion.identity, _container.transform);

                cell.WallLeft.SetActive(_maze.Cells[x, y].WallLeft);
                cell.WallBottom.SetActive(_maze.Cells[x, y].WallBottom);
                _cell = cell;
            }
        }

        //_cell.Ground.transform.position = 
        //_path.DrawPath();
        _cell.Ground.SetActive(true);
        _cell.Ground.transform.position = _path.LastPosition(_path.DrawPath());
    }
}
