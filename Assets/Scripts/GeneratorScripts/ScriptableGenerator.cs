using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="VehicleGenerator", fileName ="VehicleGenerator")]
public class ScriptableGenerator : ScriptableObject
{
    public List<GameObject> Vehicles;
    public int indexOfchosedCar;
}
