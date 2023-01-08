using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KASearchNode : MonoBehaviour
{
    public static KASearchNode GetRandomSearchNode()
    {
        KASearchNode[] searchNodes = FindObjectsOfType<KASearchNode>();
        return searchNodes[Random.Range(0, searchNodes.Length)];
    }
}
