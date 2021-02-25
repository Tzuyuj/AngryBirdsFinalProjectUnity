﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), -1);

        }
    }
}
