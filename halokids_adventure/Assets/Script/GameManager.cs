using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Dadu dadu;
    public QuizManager quiz;
    public PlayerMovement playerMovement;

    int activePlayer, angkaDadu;

    public GameObject Win;

    public Text winnertxt;

    public AudioSource source;
    public AudioClip gameover;

    [System.Serializable]
    public class Player
    {
        public PlayerMovement playerMovement;

        public string namaPlayer;

        public GameObject rollButton;
        public enum TipePlayer
            {
                Human,
                CPU
            }
        public TipePlayer tipePlayer;
    }
    public List<Player> playerList = new List<Player>();

    public enum States 
    {
        WAITING,
        ROLL_DICE,
        JAWAB_QUIZ,
        SWITCH_Player
    }
    public States state;

    void Awake()
    {
        instance = this;

        for (int i = 0; i < playerList.Count; i++)
        {
            if (SaveSetting.tipeplayer[i] == "Human")
            {
                playerList[i].tipePlayer = Player.TipePlayer.Human;
            }
            if (SaveSetting.tipeplayer[i] == "CPU")
            {
                playerList[i].tipePlayer = Player.TipePlayer.CPU;
            }
        }
    }
    void Start()
    {
        DeactiveAllButton();
        Win.SetActive(false);
        quiz.GameOverPanel.SetActive(false);
        quiz.Quizpanel.SetActive(false);
    }

    void Update()
    {
        if (playerList[activePlayer].tipePlayer == Player.TipePlayer.CPU)
        {
            switch (state)
            {
                case States.WAITING:
                    //ga ngapa-ngapain
                    break;
                case States.ROLL_DICE:
                    StartCoroutine(TungguRoll());
                    print("CPU maju :"+angkaDadu);
                    state = States.WAITING;
                    break;
                case States.JAWAB_QUIZ:

                    state = States.WAITING;
                    break;
                case States.SWITCH_Player:
                    activePlayer++;
                    activePlayer %= playerList.Count;
                    state = States.ROLL_DICE;
                    break;
            }
        }
        if (playerList[activePlayer].tipePlayer == Player.TipePlayer.Human) 
        {
            switch (state)
            {
                case States.WAITING:
                    //ga ngapa-ngapain
                    break;
                case States.ROLL_DICE:
                    ActiveSpesificButton(true);
                    state = States.WAITING;
                    break;
                case States.JAWAB_QUIZ:
                    ActiveSpesificButton(false);
                    quiz.GeneratePertanyaan();
                    state = States.WAITING;
                    break;
                case States.SWITCH_Player:
                    activePlayer++;
                    activePlayer %= playerList.Count;
                    state = States.ROLL_DICE;
                    break;
            }
        }
    }
    IEnumerator TungguRoll()
    {
        yield return new WaitForSeconds(3);
        dadu.RollDadu();
    }
    public void RollAngka(int diceNumber)
    {
        
        angkaDadu = diceNumber;
        Debug.Log("angka dadu : "+angkaDadu);
        //Ganti Giliran
        playerList[activePlayer].playerMovement.Giliran(angkaDadu);
    }

    void DeactiveAllButton()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            playerList[i].rollButton.SetActive(false);
        }
    }

    public void ActiveSpesificButton(bool on)
    {
        playerList[activePlayer].rollButton.SetActive(on);
    }
    public void ManualRollDice()
    {
        ActiveSpesificButton(false);
        StartCoroutine(TungguRoll());
    }
    public void ReportPemenang()
    {
        DeactiveAllButton();
        Win.SetActive(true);
        source.PlayOneShot(gameover);
        winnertxt.text = playerList[activePlayer].namaPlayer + " Menang";
    }

    public void BackMainMenu()
    {
        SceneLoad.Load(SceneLoad.Scene.MainMenu1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
