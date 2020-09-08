using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MovementControl : MonoBehaviour
{
    [Range(0, 10000f)]
    public float Impulse = 5000f;

    Rigidbody2D rigidb;

    private void Start()
    {
        if (rigidb == null)
            rigidb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidb.AddForce(Vector2.left * Time.deltaTime, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidb.AddForce(Vector2.right * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
