using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoad 
{
    public enum Scene 
    { 
        MainMenu1,
        PickPlayer1,
        Game1,
        Game2
    }
    public static void Load(Scene sc) 
    {
        SceneManager.LoadScene(sc.ToString());
    }
}
