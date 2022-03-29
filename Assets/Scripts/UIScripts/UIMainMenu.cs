using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIMainMenu : MonoBehaviour
{
    public ScriptableGenerator generator;
    public int index;
    public List <VehilceTemplate> template;
    [SerializeField] GameObject garageUIMenu;
    [SerializeField] GameObject choseLevelUIMenu;
    
    public  new string name;
    public Scrollbar horsePowerScroll;
    public Scrollbar backWheelRadius;
    public Scrollbar frontWheelRadius;
    public Scrollbar forwardSpring;
    public Scrollbar backSpring;
    public Scrollbar forwardDamper;
    public Scrollbar backDamper;
    public Scrollbar breakForce;
    public Scrollbar forwardTargetPosition;
    public Scrollbar backTargetPosition;

    private void Update()
    {
        index = generator.indexOfchosedCar;

        template[index].horsePower = Mathf.Lerp(0, 2000, horsePowerScroll.value);

        template[index].frontWheelRadius = Mathf.Lerp(0, 1, frontWheelRadius.value);
        template[index].backWheelRadius = Mathf.Lerp(0, 1, backWheelRadius.value);
        template[index].forwardSpring = (int) Mathf.Lerp(0,60000, forwardSpring.value);
        template[index].backSpring = (int)Mathf.Lerp(0,60000, backSpring.value);
        template[index].forwardDamper =(int) Mathf.Lerp(0,6000,forwardDamper.value);
        template[index].backDamper = (int)Mathf.Lerp(0, 6000, backDamper.value);
        template[index].breakForce = Mathf.Lerp(500, 5000, breakForce.value);
        template[index].forwardTargetPosition = forwardTargetPosition.value;
        template[index].backTargetPosition = backTargetPosition.value;

    }
    public void Race()
    {
        SceneManager.LoadScene(GameManager.instance.ChosedSceneIndex);
    }

    public void GoToLevelChoser()
    {
        garageUIMenu.SetActive(false);
        choseLevelUIMenu.SetActive(true);
    }
    public void GpToGarage()
    {
        garageUIMenu.SetActive(true );
        choseLevelUIMenu.SetActive(false);
    }

}

