using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Vehicle", fileName ="Vehicle")]
public class VehilceTemplate : ScriptableObject
{
    
    public new string name;
    public float horsePower;
    public float backWheelRadius;
    public float frontWheelRadius;  
    public int forwardSpring;
    public int backSpring;
    public int forwardDamper;
    public int backDamper;
    public float breakForce;
    public float forwardTargetPosition;
    public float backTargetPosition;
    public Vector3 centerOfMass;

}
