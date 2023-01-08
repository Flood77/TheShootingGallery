using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAIdleState : KAState
{
    public override void Enter(KAAgent owner)
    {
        Debug.Log(GetType().Name + " Enter");
    }

    public override void Execute(KAAgent owner)
    {
        KASearchPath searchPath = owner.GetComponent<KASearchPath>();
        searchPath.Move(owner.movement);

        GameObject[] gameObjects = owner.perception.GetGameObjects();
        GameObject player = KAPerception.GetGameObjectFromTag(gameObjects, "Player");

        if (player != null)
        {
            ((KAStateAgent)owner).StateMachine.SetState("KAAttackState");
        }
    }

    public override void Exit(KAAgent owner)
    {
        Debug.Log(GetType().Name + " Exit");
    }
}
