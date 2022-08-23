using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private Shield _shield;

    private int _time;

    private void Update()
    {
        _time = (int)Mathf.Round(_shield.Timer);
        _timeText.text = _time.ToString();
    }
}
