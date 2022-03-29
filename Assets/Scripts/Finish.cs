using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject nextLevelButton;
   

    private void Start()
    {
       
        nextLevelButton.SetActive(false);
        
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<VehicleConroller>() != null)
        {
            
            levelManager.Finish();
            nextLevelButton.SetActive(true);
        }
    }
}
