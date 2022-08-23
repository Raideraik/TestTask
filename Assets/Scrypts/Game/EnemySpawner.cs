using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _obstacle;
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _bottomWall;
    [SerializeField] private int _maxSpawnChance;
    [SerializeField] private int _minSpawnChance;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);
        var r = Random.Range(0, 100);
        if (!_leftWall.activeSelf || _bottomWall.activeSelf)
        {

            if (r > _minSpawnChance && r < _maxSpawnChance)
            {
                _obstacle.gameObject.SetActive(true);
            }
        }
    }
}
