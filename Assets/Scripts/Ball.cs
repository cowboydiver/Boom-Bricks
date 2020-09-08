using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float setSpeed = 5f;

    Rigidbody2D rigidb;
    [SerializeField]
    AudioClip ballBounce;
    [SerializeField]
    AudioClip killSound;

    void Start()
    {
        if (!rigidb)
            rigidb = GetComponent<Rigidbody2D>();

        GameManager.Instance.AddBall(this);
    }

    void Update()
    {
        //ClampSpeed();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SoundManager.Instance.RandomSoundEffect(ballBounce);
    }

    //Make sure the ball is always going a certain speed
    void ClampSpeed()
    {
        float speed = rigidb.velocity.magnitude;

        if(!Mathf.Approximately(speed, setSpeed))
        {
            rigidb.velocity = rigidb.velocity.normalized * speed;
        }

    }

    /// <summary>
    /// Used to start the ball
    /// </summary>
    public void Launch()
    {
        rigidb.velocity = Vector2.down * Time.fixedDeltaTime * 300f;
    }

    public void Kill()
    {
        SoundManager.Instance.RandomSoundEffect(killSound);
        //TODO: spawn explosion/particles
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveBall(this); //This notation keeps on giving
    }
}
