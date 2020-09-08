using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBrick : Brick
{
    public override IEnumerator Kill()
    {
        yield return base.Kill();

        yield break;
    }
}
