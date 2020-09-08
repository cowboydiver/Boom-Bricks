using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            other.GetComponent<Ball>().Kill();
        }
    }
}
