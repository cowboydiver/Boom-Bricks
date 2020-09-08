using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBrick : Brick
{
    public override IEnumerator Kill()
    {
        yield return base.Kill();

        yield break;
    }
}
