using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shield : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Invincibility _playerInvincibility;
    [SerializeField] private float _invincibilityTime;

    private bool _isPressed = false;
    private float _time = 0;

    public float Timer => _time;

    private void Update()
    {
        if (_isPressed)
        {
            _time += Time.deltaTime;
            if (_invincibilityTime >= _time)
                ActivateShield();

            else
                ResetTime();
        }

    }

    private void ActivateShield()
    {

        _playerInvincibility.MakeInvincible();

    }

    private void ResetTime()
    {
        _isPressed = false;
        _time = 0;
        DeactivateShield();
    }

    private void DeactivateShield()
    {
        _playerInvincibility.MakeMortal();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetTime();
    }
}
