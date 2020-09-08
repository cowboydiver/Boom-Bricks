using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Place on Ball
/// </summary>
public class PadAngledShot : MonoBehaviour
{
    Rigidbody2D thisRigidbody;

    private void Start()
    {
        if (!thisRigidbody)
            thisRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Pad")
        {
            float padhalfwidth = other.collider.bounds.extents.x;
            ContactPoint2D contact = other.GetContact(0); //Just get the first contact point
            float outAngle = (contact.point.x - other.transform.position.x) / padhalfwidth * 45f;

            //Abort if it is an edge hit
            if (outAngle > 45f || outAngle < -45f)
                return;

            //Convert angle for use with unit circle
            outAngle = 90f - (outAngle);
            float speed = thisRigidbody.velocity.magnitude;
            Vector2 newVelocity = speed * ExtentionMethods.DegreeToVector2(outAngle);

            thisRigidbody.velocity = newVelocity;    
        }
    }
}
