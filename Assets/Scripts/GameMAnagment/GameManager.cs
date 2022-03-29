using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameMenu;
    private bool gameIsPaused= false;
   
    public int ProgressLevel { get; private set; }
    public int ChosedSceneIndex { get ; private set; }

    private void Awake()
    {
       
        ChosedSceneIndex = 1;
        LoadProgress();
    }
    void Start()
    {
       
        if (instance !=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
       
        gameMenu.SetActive(false);

    }

    private void Update()
    {
        if( !gameIsPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            
            Pause();
            Debug.Log("Pause");
            gameIsPaused = true;

        }
       else if( gameIsPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
            Debug.Log("Resume");
            gameIsPaused = false;
        }
    }
    public void PromoteProgress( int sceneIndex)
    {
        if(sceneIndex >ProgressLevel)
        {
            ProgressLevel = sceneIndex;
            SaveProgress();
        }
    }



    public void Pause()
    {  
        Time.timeScale = 0f;
        gameMenu.SetActive(true);
    }
    public void GoToGarage()
    {
        SceneManager.LoadScene("Garage");
        gameMenu.SetActive(false);
        Time.timeScale = 1f;
    }
  
    public void Resume()
    {
       
        Time.timeScale = 1f;
        gameMenu.SetActive(false);
    }

    public void ExitApp()
    {
#if UNITY_EDITOR
       
        UnityEditor.EditorApplication.isPlaying = false;
       
#endif
        Application.Quit();
    }
    
    public void ChoosedScene(int chosedSceneIndex)
    {
       ChosedSceneIndex = chosedSceneIndex;
    }

    [System.Serializable]
    
    public class GameData
    {
        public int progressLevel;
    }

    public void SaveProgress()
    {
        GameData data = new GameData();
        data.progressLevel = ProgressLevel;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath +"/SaveGameData.json", json);
        Debug.Log("Saved");
        
    }
    public void LoadProgress()
    {
        string path = Application.persistentDataPath + "/SaveGameData.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            ProgressLevel = data.progressLevel;
            Debug.Log("Progress Loaded");
        }
    }
}
