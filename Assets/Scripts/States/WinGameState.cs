using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameState : GameState
{
    public WinGameState()
    {

    }

    public override IEnumerator StateEnter()
    {
        Debug.Log("Change state to WinGameState");

        yield break;
    }
}
