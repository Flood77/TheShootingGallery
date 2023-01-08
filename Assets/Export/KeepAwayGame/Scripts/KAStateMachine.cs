using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAStateMachine : MonoBehaviour
{
    public KAState initialState;

    Dictionary<string, KAState> states = new Dictionary<string, KAState>();

    public KAAgent Owner { get; set; }
    public KAState State { get; set; }

    private void Start()
    {
        Owner = GetComponent<KAAgent>();
        KAState[] states = GetComponents<KAState>();

        foreach(KAState state in states)
        {
            this.states.Add(state.GetType().Name, state);
        }

        SetState(initialState);
    }

    public void Execute()
    {
        State?.Execute(Owner);
    }

    public void SetState(string stateName)
    {
        if (states.ContainsKey(stateName))
        {
            SetState(states[stateName]);
        }
    }

    public void SetState(KAState newState)
    {
        if(newState != State)
        {
            State?.Exit(Owner);
            State = newState;
            newState.Enter(Owner);
        }
    }
}
