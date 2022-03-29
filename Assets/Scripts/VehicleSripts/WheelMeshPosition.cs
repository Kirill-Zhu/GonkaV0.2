using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMeshPosition : MonoBehaviour
{
    public WheelCollider wheel;
    private Vector3 position;
    private Quaternion rotation;
    public Vector3 scale;

    private void Update()
    {
        wheel.GetWorldPose(out position, out rotation);
        scale = new Vector3(transform.localScale.x, wheel.radius*2, wheel.radius*2);
        transform.localScale = scale;
        transform.position = position;
        transform.rotation = rotation;
        
    }

}
