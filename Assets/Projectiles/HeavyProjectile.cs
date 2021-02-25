using UnityEngine;
using System.Collections;

public class HeavyProjectile : MonoBehaviour
{
    public Vector3 v;                           // velocity

    public float linear_damping;                // for damping

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
        linear_damping = 0.999f;
    }


    // Update is called once per frame
    void Update()
    {
        // Use this as your time step
        float dt = 0.02f;
        Quaternion rotation = transform.rotation;
        
        if (timer == timeout)
        {
            Destroy(this.gameObject);
           
        }

            //Only have vertical force (gravity)
            //Arbitrary gravity of 10
            
            v.y = v.y - (dt * 10f);
            v = linear_damping * v;
            
            timer++;

            //Adusting the angle of the projectile
            angle = Mathf.Abs(Mathf.Atan(5f/ v.x));
            transform.Rotate(angle, 0, 0);
            
        

        Vector3 position = transform.position;

            position = position + dt * v;

            //Heavy projectile, don't want any bounce off the ground
            if (position.y < 0.5)
            {
                position.y = 0.5f;
            }
        


        transform.position = position;
    }

    public void Launch(Vector3 linearVelocity)
    {
        v = linearVelocity;
    }

    public void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("lb_bird"))
        {
            GameObject.Find("Canvas").GetComponent<UI>().updateScore(10);
        }


    }
}