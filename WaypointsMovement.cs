using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    [SerializeField] private Transform _waypoints;

    private Transform[] _pointsPosition;
    private float _speedMove;
    private int _pointIndex;

    private void Start()
    {
        _pointsPosition = new Transform[_waypoints.childCount];

        for (int i = 0; i < _waypoints.childCount; i++)
            _pointsPosition[i] = _waypoints.GetChild(i);
    }

    public void Update()
    {
        var currentPoint = _pointsPosition[_pointIndex];
        transform.position = Vector3.MoveTowards(transform.position,
            currentPoint.position, _speedMove * Time.deltaTime);

        if (transform.position == currentPoint.position)
            GetNextPoint();
    }

    private Vector3 GetNextPoint()
    {
        _pointIndex++;

        if (_pointIndex == _pointsPosition.Length)
            _pointIndex = 0;

        var pointDirection = arrayPlaces[NumberOfPlaceInArrayPlaces].transform.position;
        transform.forward = pointDirection - transform.position;
        return pointDirection;
    }
}