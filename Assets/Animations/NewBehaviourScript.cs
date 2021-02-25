using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        float verticalSpeed = Input.GetAxis("Vertical");
        float direction = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", verticalSpeed);
        animator.SetFloat("Direction", direction, 0.25f, Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("Dying1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("Reviving2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetTrigger("Wave3");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("JumpSpace");
        }

    }
}

