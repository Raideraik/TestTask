using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryParticleShow : MonoBehaviour
{
    [SerializeField]private ParticleSystem _particleSystem;
    private  void Update()
    {
        if (Time.timeScale < 0.01f)
        {
            _particleSystem.Simulate(Time.unscaledDeltaTime, true, false);
        }
    }
}
