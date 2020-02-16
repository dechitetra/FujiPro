﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, this.gameObject.transform.position.z);
    }
}
