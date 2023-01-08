using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public KeepAwaySession session;

    private void OnTriggerEnter(Collider other)
    {
        session.State = KeepAwaySession.eState.GameOver;
    }
}
