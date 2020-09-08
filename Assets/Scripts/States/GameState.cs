using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{

    public GameState()
    { 
    }
    public virtual IEnumerator StateEnter() { yield break; }
    public virtual IEnumerator StateExit() { yield break; }
}
