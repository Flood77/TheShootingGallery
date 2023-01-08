using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAAttackState : KAState
{
    float timer;
    Vector2 lastSeenPosition;

    public override void Enter(KAAgent owner)
    {
        Debug.Log(GetType().Name + " Enter");
    }

    public override void Execute(KAAgent owner)
    {
        GameObject[] gameObjects = owner.perception.GetGameObjects();
        GameObject player = KAPerception.GetGameObjectFromTag(gameObjects, "Player");

        if(player != null)
        {
            lastSeenPosition = player.transform.position;
            timer = 1;
        }
           
        owner.movement.MoveTowards(lastSeenPosition);

        if (player == null)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                ((KAStateAgent)owner).StateMachine.SetState("KAIdleState");
            }
        }
    }

    public override void Exit(KAAgent owner)
    {
        Debug.Log(GetType().Name + " Exit");
    }
}
