using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class VehicleConroller : MonoBehaviour
{
    public VehilceTemplate vehilceTemplate;
   

    public List<WheelCollider> forwardWheelColliders;
    public List<WheelCollider> backWheelColliders;
   
    public float horsePower;
   
  

    private float vertInput;
    public float breakTorque = 1000f;
    private float horIutput;
    public float steerAngle = 35f;
    private Rigidbody rb;
    public Vector3 centerOfMass;
    public bool isGrounded;

  
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    private void Update()
    {
        vertInput = Input.GetAxis("Vertical");
        horIutput = Input.GetAxis("Horizontal");
        horsePower = vehilceTemplate.horsePower;
        breakTorque = vehilceTemplate.breakForce;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
        
    }

    private void FixedUpdate()
    {
        VehicleSettings();
        VehicleContorller();    
        GroundCheck();
    
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + transform.rotation * centerOfMass, 0.3f);
        
    }
    private void VehicleSettings()
    {

        centerOfMass = vehilceTemplate.centerOfMass;
        foreach (WheelCollider forwardWheel in forwardWheelColliders)
        {
            forwardWheel.radius = vehilceTemplate.frontWheelRadius;
            var suspesionSpring = forwardWheel.suspensionSpring;
            suspesionSpring.spring = vehilceTemplate.forwardDamper;
            suspesionSpring.damper = vehilceTemplate.forwardDamper;
            suspesionSpring.targetPosition = vehilceTemplate.forwardTargetPosition;
            forwardWheel.suspensionSpring = suspesionSpring;
        }



        foreach (WheelCollider backWheel in backWheelColliders)
        {
            backWheel.radius = vehilceTemplate.backWheelRadius;
            var suspesionSpring = backWheel.suspensionSpring;
            suspesionSpring.spring = vehilceTemplate.backSpring;
            suspesionSpring.damper = vehilceTemplate.backDamper;
            suspesionSpring.targetPosition = vehilceTemplate.backTargetPosition;
            backWheel.suspensionSpring = suspesionSpring;

        }
    }

    private void VehicleContorller()
    {
        foreach (WheelCollider forwardWheel in forwardWheelColliders)
        {
            forwardWheel.steerAngle = horIutput * steerAngle;
            forwardWheel.radius = vehilceTemplate.frontWheelRadius;


        }
        foreach (WheelCollider backWheel in backWheelColliders)
        {
            backWheel.motorTorque = vertInput * horsePower;
            backWheel.radius = vehilceTemplate.backWheelRadius;
            if (Input.GetKey(KeyCode.Space))
            {
                backWheel.brakeTorque = breakTorque;
            }

            else
            {
                backWheel.brakeTorque = 0f;
            }

        }
    }

    private void GroundCheck()
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                isGrounded = true;
            }
            else
                isGrounded = false;
        }

    }

    public void Reset()
    {
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));

        RaycastHit hit;
     
        if(Physics.Raycast(ray,out hit,5f))
        {
            
                transform.position = hit.point + new Vector3(0,3,0);
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
                rb.velocity = Vector3.zero;
                rb.Sleep();
            
        }

    }

}
