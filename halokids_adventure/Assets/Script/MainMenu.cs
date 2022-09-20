using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Aboutpanel;
    public GameObject CreditPanel;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public GameObject tutorial5;
    public GameObject tutorial;
    private void Awake()
    {
        Aboutpanel.SetActive(false);
        CreditPanel.SetActive(false);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
        tutorial.SetActive(false);
    }
    public void StartGame()
    {
        SceneLoad.Load(SceneLoad.Scene.PickPlayer1);
    }
    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

    public void AboutGame()
    {
        Aboutpanel.SetActive(true);
    }
    public void AboutBack()
    {
        Aboutpanel.SetActive(false);
    }
    public void CreditGame()
    {
        CreditPanel.SetActive(true);
    }
    public void CreditBack()
    {
        CreditPanel.SetActive(false);
    }
    public void Tutorial1() 
    {
        tutorial.SetActive(true);
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
    }
    public void Tutorial2()
    {
        tutorial.SetActive(true);
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
    }
    public void Tutorial3()
    {
        tutorial.SetActive(true);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(true);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
    }
    public void Tutorial4()
    {
        tutorial.SetActive(true);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(true);
        tutorial5.SetActive(false);
    }
    public void Tutorial5()
    {
        tutorial.SetActive(true);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(true);
    }
    public void TutorialBack()
    {
        tutorial.SetActive(false);
    }
}
