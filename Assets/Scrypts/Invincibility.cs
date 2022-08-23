using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    [SerializeField] private Material _invincibiltyColor;
    [SerializeField] private MeshRenderer _color;
    private Material _startColor;
    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _startColor = _color.material;
    }

    public void MakeInvincible()
    {        
        _collider.enabled = false;
        _color.material = _invincibiltyColor;
    }

    public void MakeMortal() 
    {
        _color.material = _startColor;
        _collider.enabled = true;
    }

}
