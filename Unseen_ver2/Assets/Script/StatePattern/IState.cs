using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IState
{
    private Action enterAction;
    private Action updateAction;
    private Action exitAction;

    public IState(Action enter, Action update, Action exit)
    {
        enterAction = enter;
        updateAction = update;
        exitAction = exit;
    }

    public void Enter()
    {
        if (enterAction != null)
            enterAction();
    }

    public void Update()
    {
        if (updateAction != null)
            updateAction();
    }

    public void Exit()
    {
        if (exitAction != null)
            exitAction();
    }
}
