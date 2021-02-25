using UnityEngine;
using System.Collections;

public class ExplosiveProjectile : MonoBehaviour
{
    public Transform effect;

    public Vector3 v;                           // velocity

    public float linear_damping;                // for damping


    public float angle = 0;

    public int timeout;
    private int timer;
    // Use this for initialization
    void Start()
    {
        //Initialize coefficients
        linear_damping = 0.999f;
       
        timeout = 200;
        timer = 0;
        angle = 90 - transform.localEulerAngles.x;
        
    }


    // Update is called once per frame
    void Update()
    {
        // Use this as your time step
        float dt = 0.03f;
        Quaternion rotation = transform.rotation;


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
        


        transform.position = position;
    }

    public void Launch(Vector3 linearVelocity)
    {
        v = linearVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Transform effectInstance = (Transform)Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
        string tag = collision.gameObject.tag;
        if (tag.Equals("lb_bird"))
        {
            collision.gameObject.GetComponent<lb_Bird>().KillBird();
        }
    }
}