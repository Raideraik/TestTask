using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _victory;

    private void OnEnable()
    {
        _player.Victory += ShowVictoryScreen;
    }

    private void OnDisable()
    {
        _player.Victory -= ShowVictoryScreen;
    }

    private void ShowVictoryScreen()
    {
        Time.timeScale = 0;
        _victory.SetActive(true);
    }
}
