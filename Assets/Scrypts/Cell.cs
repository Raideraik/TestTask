using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject _wallLeft;
    [SerializeField] private GameObject _wallBottom;
    [SerializeField] private GameObject _ground;

    public GameObject WallLeft => _wallLeft;
    public GameObject WallBottom => _wallBottom;
    public GameObject Ground => _ground;

}
