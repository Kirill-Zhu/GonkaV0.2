using TMPro;
using UnityEngine;

public class ButtonLevel : MonoBehaviour
{
  public int Index { get; private set; }
   

    private void Start()
    {   
        Index = transform.GetSiblingIndex() +1;
        GetComponentInChildren<TextMeshProUGUI>().text = "LEVEL" + Index;  
    }
    public void SetSceneIndex()
    {
        GameManager.instance.ChoosedScene(Index);
    }

}
