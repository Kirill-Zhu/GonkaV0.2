using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButtons : MonoBehaviour
{
    public List<GameObject> levelButtons = new List<GameObject>();
    public GameObject button;
    private void Update()
    {
        
    }
    private void Start()
    {
        AddLevelButton();
    }
    private void AddLevelButton()
    {
        for (int i = 0; i < GameManager.instance.ProgressLevel+1; i++)
        {
            levelButtons.Add(Instantiate(button));
            levelButtons[i].transform.SetParent(transform, true);
        }
   
    }
}
