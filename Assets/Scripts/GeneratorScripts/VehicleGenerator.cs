using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleGenerator : MonoBehaviour
{
    public ScriptableGenerator generator;
    public GameObject choosedVehicle;
    public int index;
    private void Start()
    {
     
       
        choosedVehicle =  Instantiate(generator.Vehicles[0], transform.position, transform.rotation);

    }
    private void Update()
    {
        index = Mathf.Clamp(index, 0, generator.Vehicles.Count - 1);
        generator.indexOfchosedCar = index;

    }


    
    
  
    
    public void NextVehicle()
    {
        if(index<generator.Vehicles.Count-1)
        {
            index++;
            Destroy(choosedVehicle);
            choosedVehicle = Instantiate(generator.Vehicles[index],transform.position, transform.rotation);
        }
        
       
        
    }
    public void PreviousVehicle()
    {
       
       if(index > 0)
        {
            index--;

            Destroy(choosedVehicle);
            choosedVehicle = Instantiate(generator.Vehicles[index],transform.position, transform.rotation);
        } 
       
       

    }

}
