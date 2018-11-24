using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputKey
{
    WALK_LEFT = -1,
    WALK_RIGHT = 1,
    JUMP,
    RELEASE,
    NONE,
}

public class InputHandle{
    public InputKey HandleInput()
    {
        if (Input.GetButtonDown("Jump"))
            return InputKey.JUMP;
        if (Input.GetAxisRaw("Horizontal") > 0)
            return InputKey.WALK_RIGHT;
        if (Input.GetAxisRaw("Horizontal") < 0)
            return InputKey.WALK_LEFT;
        if (Input.GetAxisRaw("Horizontal") == 0)
            return InputKey.RELEASE;
        return InputKey.NONE;
    }
}
