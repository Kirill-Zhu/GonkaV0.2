using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public ScriptableGenerator vehicleGenerator;
    public GameObject car;
   
    private void Awake()
    {

        car = Instantiate(vehicleGenerator.Vehicles[vehicleGenerator.indexOfchosedCar], transform.position, transform.rotation);

    }


    public void SpawnNewCar()
    {
        Destroy(car);
        car = Instantiate(vehicleGenerator.Vehicles[vehicleGenerator.indexOfchosedCar], transform.position, transform.rotation);
    }

}
