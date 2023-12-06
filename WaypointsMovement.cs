using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    [SerializeField] private Transform _way;

    private Transform[] _waypoints;
    private Transform _currentPoint;
    private float _speedMove;
    private int _pointIndex;

    private void Start()
    {
        _waypoints = new Transform[_way.childCount];

        for (int i = 0; i < _way.childCount; i++)
            _waypoints[i] = _way.GetChild(i);

        _currentPoint = _waypoints[_pointIndex];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _currentPoint.position, _speedMove * Time.deltaTime);

        if (transform.position == _currentPoint.position)
            GetNextPoint();
    }

    private void GetNextPoint()
    {
        _pointIndex++;

        if (_pointIndex == _waypoints.Length)
            _pointIndex = 0;

        _currentPoint = _waypoints[_pointIndex];
        transform.forward = _currentPoint.position - transform.position;
    }
}