using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  public SpawnManager spawnManager;
  public GameObject car;


    private void Start()
    {
        car = spawnManager.car;
    }
    private void Update()
    {
        GoToRespawn();
      
    }
    public void GoToRespawn()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            car.transform.position = spawnManager.transform.position;
            car.transform.rotation = spawnManager.transform.rotation;
            car.GetComponent<VehicleConroller>().Reset();
            spawnManager.SpawnNewCar();
            car = spawnManager.car;
        }
       
    }
    public void Finish()
    {
        GameManager.instance.ChoosedScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.instance.PromoteProgress(SceneManager.GetActiveScene().buildIndex);
      

    }
    
    public void StartNextLevel()
    {
        SceneManager.LoadScene(GameManager.instance.ChosedSceneIndex);
    }
}
