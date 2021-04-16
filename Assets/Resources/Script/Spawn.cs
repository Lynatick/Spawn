using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentPoint;

    public GameObject Template;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for(int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        if(Time.fixedTime % 2 == 0)
        {
            Transform target = _points[_currentPoint];
            GameObject gameObject = Instantiate(Template, target.position, Quaternion.identity);
            _currentPoint++;

            if(_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
