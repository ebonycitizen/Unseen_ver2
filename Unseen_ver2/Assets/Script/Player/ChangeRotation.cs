using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRotation
{
    public enum Direction
    {
        Right,
        Left
    }

    Vector3 rotationSpeed = new Vector3(0, 20, 0);

    public Direction direction { get; private set; }
    public bool turnOverEnable { get; private set; }

    public ChangeRotation()
    {
        direction = Direction.Right;
        turnOverEnable = false;
    }

    public void ResetRotation()
    {
        direction = Direction.Right;
    }

    public void ChangeDirection(float vec, GameObject obj)
    {
        if (direction == Direction.Right)
        {
            if (vec == -1)
                turnOverEnable = true;
        }
        if (direction == Direction.Left)
        {
            if (vec == 1)
                turnOverEnable = true;
        }

        //左へ回転
        if (turnOverEnable && direction == Direction.Right)
        {
            if (obj.transform.eulerAngles.y < 180)
                obj.transform.Rotate(rotationSpeed);
            else
            {
                direction = Direction.Left;
                turnOverEnable = false;
            }          
        }
        //右へ回転
        if (turnOverEnable && direction == Direction.Left)
        {
            if (obj.transform.eulerAngles.y >= 180 || obj.transform.eulerAngles.y < 0)
                obj.transform.Rotate(rotationSpeed);
            else
            {
                direction = Direction.Right;
                turnOverEnable = false;
            }
        }
    }
}
