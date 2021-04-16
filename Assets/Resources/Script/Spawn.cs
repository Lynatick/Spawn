using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private int _speedInSecond;
    [SerializeField] private GameObject _template;

    private Transform[] _points;
    
    private int _currentPoint,_currentSecond;
    
    private void Start()
    {
        _points = new Transform[_path.childCount];
        _currentSecond = DateTime.Now.Second;

        for(int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        int nowSecond = DateTime.Now.Second;

        if(_currentSecond < nowSecond)
        {
            if(nowSecond % _speedInSecond == 0)
            {
                Transform target = _points[_currentPoint];
                GameObject gameObject = Instantiate(_template, target.position, Quaternion.identity);
                _currentPoint++;

                if(_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
                _currentSecond = nowSecond;
            }
            if(nowSecond == 59)
                _currentSecond = -1;
        }
    }
}
