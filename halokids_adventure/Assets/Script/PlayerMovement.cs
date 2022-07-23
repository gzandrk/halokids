using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rute rute;
    public QuizManager quiz;
    public Jawaban jawab;
    public List<Titik> titikList = new List<Titik>();

    int posisiRute;

    int player_id; //apabila ada 2 player, simpen aja buat jaga2
    float speed = 2f;

    int sisaLangkah;
    int langkah;
    public int bonus_Maju;

    bool bolehMaju;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform c in rute.titikList) 
        {
            Titik t = c.GetComponentInChildren<Titik>();
            if(t!=null)
            {
                titikList.Add(t);
            }

        }
    }

    public IEnumerator Maju()
    {
        if (bolehMaju)
        {
            yield break;
        }
        bolehMaju = true;

        //Hapus player
        titikList[posisiRute].RemovePlayer(this);

        while (sisaLangkah > 0) 
        {
            posisiRute++;
            Vector3 nextPos = rute.titikList[posisiRute].transform.position;

            while (PindahTitikSelanjutnya(nextPos))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            sisaLangkah--;
            langkah++;
        }

        //Check harta berisi soal
        if (titikList[posisiRute].bonusMaju == true)
        {
            print("soal muncul");
            GameManager.instance.state = GameManager.States.JAWAB_QUIZ;
            //yield return new WaitUntil(()=>quiz.hasil);
            yield return new WaitForSeconds(10);
                if (quiz.hasil == true)
                {
                    for (bonus_Maju = quiz.bonusMaju; bonus_Maju > 0; bonus_Maju--)
                    {
                        posisiRute++;
                        Vector3 nextPos = titikList[posisiRute].transform.position;
                        while (PindahTitikSelanjutnya(nextPos))
                        {
                            yield return null;
                        }
                        yield return new WaitForSeconds(0.1f);
                        langkah++;
                    }
                }
            
            //Debug.Log("kunci = "+quiz.kunci);
        }

        //Tambah player
        titikList[posisiRute].AddPlayer(this);

        //Cek Pemenang
        if (langkah == rute.titikList.Count - 1)
        {
            GameManager.instance.ReportPemenang();
            yield break;
        }

        //UPDATE GAMEMANAGER
        GameManager.instance.state = GameManager.States.SWITCH_Player;

        bolehMaju = false;
    }

    bool PindahTitikSelanjutnya(Vector3 nextPos)
    {
        return nextPos != (transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime));
    }

    public void Giliran(int angkaDadu) 
    {
        sisaLangkah = angkaDadu;
        if (langkah + sisaLangkah < rute.titikList.Count)
        {
            StartCoroutine(Maju());
        }
        else
        {
            print("Angka terlalu besar: "+angkaDadu);
            //UPDATE GAMEMANAGER
            GameManager.instance.state = GameManager.States.SWITCH_Player;
        }
    }
}