using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public float forcePowerAtStart =10f;
    public float forcePowerUpdate = 3f;
    private Rigidbody rb;
    private void Start()
    {
      rb = GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
       
    }
}
