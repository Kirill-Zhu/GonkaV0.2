using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    public float sensivity=10f;
    private Vector3 rotation;
    public SpawnManager spawnManager;
    private void Start()
    {
       
    }
    private void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * sensivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensivity;
        mouseY = Mathf.Clamp(mouseY, -45, 45);
        rotation = new Vector3(mouseY, mouseX, 0);
        transform.localEulerAngles = rotation;
        transform.position = spawnManager.car.transform.position;
    }
}
