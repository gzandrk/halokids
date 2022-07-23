using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jawaban : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    //public Color startColor;
    public int hasil;

    private void Start()
    {
        //startColor = GetComponent<Image>().color;
    }
    public void Jawab() 
    {
        if (isCorrect)
        {
            //startColor = GetComponent<Image>().color=Color.green;
            Debug.Log("Jawaban Benar");
            hasil = 1;
            quizManager.Benar();
        }
        else 
        {
            //startColor = GetComponent<Image>().color=Color.red;
            Debug.Log("Jawaban Salah");
            hasil = 2;
            quizManager.Salah();
        }
    }
}
