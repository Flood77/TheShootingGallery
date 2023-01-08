using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KAState : MonoBehaviour
{
    public abstract void Enter(KAAgent owner);
    public abstract void Execute(KAAgent owner);
    public abstract void Exit(KAAgent owner);
}
