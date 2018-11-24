using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Action();

public class StateMachine<T> {
    private Dictionary<T, IState> statePool = new Dictionary<T, IState>();
    private IState currentState = new IState(null,null,null);

    public void Add(T stateType, Action enter, Action update, Action exit)
    {
        if (statePool.ContainsKey(stateType))
            return;
        statePool.Add(stateType, new IState(enter, update, exit));
    }

    public void Change(T stateType)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = statePool[stateType];
        currentState.Enter();
    }

    public void Clear()
    {
        statePool.Clear();
    }

    public void Update()
    {
        if (currentState == null)
            return;
        currentState.Update();
    }
}
