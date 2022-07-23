using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rute : MonoBehaviour
{
    Transform[] titik;
    public List<Transform> titikList = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        FillNodes();
    }

    // Update is called once per frame
    void FillNodes()
    {
        titikList.Clear();
        titik = GetComponentsInChildren<Transform>();

        int angka = -1;
        foreach (Transform child in titik) {
            Titik t = child.GetComponent<Titik>();
            if (child != this.transform && t != null) 
            {
                angka++;
                titikList.Add(child);
                child.gameObject.name = "field" + angka;
                t.SetTitikId(angka);
            }
        }
    }
    void OnDrawGizmos()
    {
        FillNodes();
        for (int i = 0; i < titikList.Count; i++)
        {
            Vector3 start = titikList[i].position;
            if (i > 0)
            {
                Vector3 prev = titikList[i - 1].position;
                Debug.DrawLine(prev, start, Color.green);
            }
        }
    }
}
