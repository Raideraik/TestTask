using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Path _positions;
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private GameObject _victoryEffect;

    private int _pointIndex = 0;
    private Vector3 _deathPosition;
    private bool _victory;
    private bool _started = false;

    public event UnityAction Died;
    public event UnityAction Victory;
    private void Start()
    {
        SetPlayer(_positions);
        StartCoroutine(WaitToMove());
    }
    private void Update()
    {
        if (_started)
        if (!_victory)
        {
            Move(_positions);
        }
    }

    private void Move(Path positions)
    {
        transform.position = Vector3.MoveTowards(transform.position, positions.DrawPath()[_pointIndex], _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, positions.DrawPath()[_pointIndex]) <= 0.2f)
            _pointIndex++;

        if (Vector3.Distance(transform.position, positions.LastPosition(positions.DrawPath())) <= 0.2f)
            WinLevel();
    }

    private Vector3 SetPlayer(Path positions)
    {
        transform.position = positions.DrawPath()[_pointIndex];
        return transform.position;
    }

    private void WinLevel()
    {
        Victory?.Invoke();
        _victory = true;
        _victoryEffect.SetActive(true);
    }

    public void Death()
    {
        //GameObject effect = (GameObject)Instantiate(_deathEffect, transform.position, Quaternion.identity);
        _deathPosition = transform.position;
        StartCoroutine(ShowDeathEffect());
        Died?.Invoke();
        _pointIndex = 0;
        //transform.position = _startPosition;
    }

    IEnumerator ShowDeathEffect()
    {
        _deathEffect.transform.position = _deathPosition;
        _deathEffect.SetActive(true);

        yield return new WaitForSeconds(2);

        _deathEffect.SetActive(false);
    }

    IEnumerator WaitToMove() 
    {
        yield return new WaitForSeconds(2);
        _started = true;
    }
}
