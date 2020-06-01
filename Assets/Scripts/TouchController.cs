using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Direction
{
    NONE, LEFT, RIGHT
}

public class TouchController : MonoBehaviour
{
    public Action<Direction> Touched;

    Vector2 startTouch;
    Vector2 endTouch;

    [SerializeField]
    float touchSensitive = 400f;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouch = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouch = Input.GetTouch(0).position;
            var currentDirection = GetDirection(endTouch - startTouch);
            Touched?.Invoke(currentDirection);
        }
    }

    Direction GetDirection(Vector3 directionVector)
    {
        if (Mathf.Abs(directionVector.x) < touchSensitive && Mathf.Abs(directionVector.y) < touchSensitive)
            return Direction.NONE;

        if (directionVector.x > 0)
            return Direction.LEFT;
        else
            return Direction.RIGHT;
    }

}
