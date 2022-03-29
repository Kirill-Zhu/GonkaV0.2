using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    void Start()
    {
        offset = new Vector3(0, 5, -8);
        transform.position += offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position);
    }
  }
