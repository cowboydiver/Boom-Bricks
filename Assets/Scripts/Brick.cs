using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Brick : MonoBehaviour
{
    [SerializeField]
    int health = 1;
    void Start()
    {
        Init();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Ball")
        {
            BallHit();
        }
    }

    void BallHit()
    {
        TakeDamage(1);
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 1)
            StartCoroutine(Kill());
    }

    public virtual IEnumerator Init()
    {
        GameManager.Instance.AddBrick(this);

        yield break;
    }

    public virtual IEnumerator Kill()
    {
        Destroy(gameObject);

        yield break;
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveBrick(this);
    }
}
