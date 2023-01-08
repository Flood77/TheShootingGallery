using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KAStateMachine))]
public class KAStateAgent : KAAgent
{
    public KAStateMachine StateMachine { get; private set; }

    void Start()
    {
        StateMachine = GetComponent<KAStateMachine>();
    }

    void Update()
    {
        animator.SetFloat("Speed", movement.Velocity.magnitude);
        StateMachine.Execute();    
    }
}
