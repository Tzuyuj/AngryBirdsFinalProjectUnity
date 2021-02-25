using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBird : MonoBehaviour
{
    Animator anim;
    int timeout = 100;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeout == 0)
        {
            Destroy(gameObject);
        }
        else if (dead)
        {
            timeout--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Explosive"))
        {
            GetComponent<lb_Bird>().KillBird();
            dead = true;

        }
        else if (tag.Equals("Heavy"))
        {
            GetComponent<lb_Bird>().KillBird();
            dead = true;
        }
        else if (tag.Equals("Fast"))
        {
            GetComponent<lb_Bird>().KillBird();
            dead = true;

        }

    }
}
