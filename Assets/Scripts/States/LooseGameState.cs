using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseGameState : GameState
{
    RetryButton retryButton;
    public LooseGameState(RetryButton retryButton)
    {
        this.retryButton = retryButton;
    }

    public override IEnumerator StateEnter()
    {
        Debug.Log("Change state to LooseGameState");

        retryButton.Init();

        yield break;
    }

    public override IEnumerator StateExit()
    {
        retryButton.Close();
        yield break;
    }
}
