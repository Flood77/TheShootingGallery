using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KAAgent : MonoBehaviour
{
    public KAPerception perception;
    public KAMovement movement;
    public Animator animator;
}
