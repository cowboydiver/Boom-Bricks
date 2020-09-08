using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : GameState
{
    List<Ball> balls;
    List<Brick> bricks;

    public PlayingState(List<Ball> balls, List<Brick> bricks)
    {
        this.balls = balls;
        this.bricks = bricks;
    }

    public override IEnumerator StateEnter()
    {
        foreach(Ball ball in balls)
        {
            ball.Launch();
        }

        Debug.Log("Change state to PlayingState");

        yield break;
    }
}
