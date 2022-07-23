using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<Pertanyaan> pertanyaan = new List<Pertanyaan>();

    public GameObject[] pilgan;
    public GameObject Quizpanel;
    public GameObject GameOverPanel;

    public int currentPertanyaan;
    public int bonusMaju;
    public int pilihan;
    public int kunci;

    public Text Pertanyaantxt;
    public Text gameovertxt;
    public Text hasiltxt;

    public bool hasil;

    // Start is called before the first frame update
    void Update()
    {
        Debug.Log("kondisi saat ini : "+hasil);
    }

    IEnumerator GameOver()
    {
        Quizpanel.SetActive(false);
        GameOverPanel.SetActive(true);
        gameovertxt.text = hasiltxt.text;
        yield return new WaitForSeconds(3);
        GameOverPanel.SetActive(false);
        //hasil = false;
    }
    public void Benar()
    {
        pertanyaan.RemoveAt(currentPertanyaan);
        hasiltxt.text = "jawabanmu benar, boleh maju "+bonusMaju+" langkah";
        hasil = true;
        StartCoroutine(GameOver());
        //return hasil;
    }
    public void Salah()
    {
        pertanyaan.RemoveAt(currentPertanyaan);
        hasiltxt.text = "jawabanmu salah";
        hasil = false;
        StartCoroutine(GameOver());
        //return hasil;
    }
    public void SetJawaban() 
    {
        for (int i = 0; i < pilgan.Length; i++) 
        {
            //pilgan[iTemp].GetComponent<Image>().color = pilgan[iTemp].GetComponent<Jawaban>().startColor;
            pilgan[i].GetComponent<Jawaban>().isCorrect = false;
            pilgan[i].transform.GetChild(0).GetComponent<Image>().sprite = pertanyaan[currentPertanyaan].jawaban[i];

            pilihan = i + 1;
            kunci = pertanyaan[currentPertanyaan].kunciJawaban;
            if (kunci == pilihan)
            {
                pilgan[i].GetComponent<Jawaban>().isCorrect = true;
                //  Benar();
                //  print("benar");
                bonusMaju = Random.Range(1, 7);
            }
        }
    }
    public void GeneratePertanyaan() 
    {
        Quizpanel.SetActive(true);
        hasil = false;
        currentPertanyaan = Random.Range(0, pertanyaan.Count);
        Pertanyaantxt.text = pertanyaan[currentPertanyaan].pertanyaan;
        SetJawaban();
    }
}
