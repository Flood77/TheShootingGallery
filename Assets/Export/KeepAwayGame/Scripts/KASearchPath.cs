using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KASearchPath : MonoBehaviour
{
    public KASearchNode initialNode;
    public KASearchNode Node { get; set; }

    void Start()
    {
        Node = initialNode;  
    }

    public void Move(KAMovement movement)
    {
        if (Node != null)
        {
            movement.MoveTowards(Node.transform.position);
        }
    }
}
