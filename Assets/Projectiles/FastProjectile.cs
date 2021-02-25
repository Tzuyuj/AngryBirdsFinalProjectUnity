using UnityEngine;
using System.Collections;

public class FastProjectile : MonoBehaviour
{
    public float angle = 0;

    public int timeout;
    private int timer;
    // Use this for initialization
    void Start()
    {
        //Initialize coefficients
        timeout = 200;
        timer = 0;
        angle = 90 - transform.localEulerAngles.x;
    }



    // Update is called once per frame
    void Update()
    {
        // Use this as your time step
        if (timer == timeout)
        {
            Destroy(this.gameObject);

        }

        timer++;

    }

    public void Launch(Vector3 linearVelocity)
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(2500 * linearVelocity);
    }

    public void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("lb_bird"))
        {
            collision.gameObject.GetComponent<lb_Bird>().KillBird();
        }

    }
}