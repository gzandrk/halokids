using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    public Toggle Hero, HeroCPU;
    public Toggle Barbarian, BarbarianCPU;
    public Toggle Wizard, WizardCPU;
    public Toggle Knight, KnightCPU;

    public GameObject Panel;

    public void Start()
    {
        Panel.SetActive(false);
    }

    public void ReadToggle() 
    {
        //Hero
        if (Hero.isOn)
        {
            SaveSetting.tipeplayer[0] = "Human";
        }
        else if (HeroCPU.isOn) 
        {
            SaveSetting.tipeplayer[0] = "CPU";
        }

        //Knight
        if (Knight.isOn)
        {
            SaveSetting.tipeplayer[1] = "Human";
        }
        else if (KnightCPU.isOn)
        {
            SaveSetting.tipeplayer[1] = "CPU";
        }
        //Wizard
        if (Wizard.isOn)
        {
            SaveSetting.tipeplayer[2] = "Human";
        }
        else if (WizardCPU.isOn)
        {
            SaveSetting.tipeplayer[2] = "CPU";
        }
        //Barbarian
        if (Barbarian.isOn)
        {
            SaveSetting.tipeplayer[3] = "Human";
        }
        else if (BarbarianCPU.isOn)
        {
            SaveSetting.tipeplayer[3] = "CPU";
        }
    }
    public void StartGame() 
    {
        Panel.SetActive(true);
        
    }
    public void DenganAR() 
    {
        ReadToggle();
        SceneLoad.Load(SceneLoad.Scene.Game1);
    }
    public void TanpaAR()
    {
        ReadToggle();
        SceneLoad.Load(SceneLoad.Scene.Game2);
    }
    public void BackMainMenu()
    {
        SceneLoad.Load(SceneLoad.Scene.MainMenu1);
    }
}
public static class SaveSetting 
{
    public static string[] tipeplayer = new string[4];
    
}
