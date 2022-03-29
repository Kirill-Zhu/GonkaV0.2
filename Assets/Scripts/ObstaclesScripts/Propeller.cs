using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public float speed = 0.5f;
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }
}
