using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Aboutpanel;
    public GameObject CreditPanel;

    private void Awake()
    {
        Aboutpanel.SetActive(false);
        CreditPanel.SetActive(false);
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
}
