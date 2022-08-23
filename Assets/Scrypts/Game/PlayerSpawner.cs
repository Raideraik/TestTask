using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Path _positions;
    [SerializeField] private Menu _menu;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void OnDied() 
    {
        _menu.Fade();
        _player.transform.position = _positions.DrawPath()[0];
    }
}
