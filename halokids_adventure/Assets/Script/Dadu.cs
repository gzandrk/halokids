using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dadu : MonoBehaviour
{
    //public DiceSideCheck[] diceSide;
    public C_SideCheck c_side;


    Rigidbody rb;

    public bool jatuh;
    public bool lempar;

    public int diceNumber;

    Vector3 initPos; //buat ngembaliin dadu ke posisi awal kalo mau lempar
    public Vector3 dicevelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPos = transform.position;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        dicevelocity = rb.velocity;
        if (rb.IsSleeping() && !jatuh && lempar) //kalau udah dilempar tapi "jatuh" belum kedeteksi
        {
            jatuh = true;
            rb.useGravity = false;
            rb.isKinematic = true;

            //cek sisi dadu
            CekSisiDadu();
        }
        else if (rb.IsSleeping() && jatuh && diceNumber == 0)
        {
            //roll lagi, tidak terdeteksi
            RollUlang();
        }
    }

    public void RollDadu()
    {
        Reset();
        if (!lempar && !jatuh)
        {
            lempar = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(45, 360), Random.Range(45, 360), Random.Range(45, 360));
        }
        else if(lempar && jatuh)
        {
            //reset posisi ke semula
            Reset();
        }

    }

    void Reset() //fungsi reset posisi dadu
    {
        transform.position = initPos;
        rb.isKinematic = false;
        lempar = false;
        jatuh = false;
        rb.useGravity = false;
    }
    
    void RollUlang() //buat  ngeRoll Dadu lagi
    {
        Reset();
        lempar = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }

    void CekSisiDadu() 
    {
       diceNumber = c_side.diceNumber;
       GameManager.instance.RollAngka(diceNumber);
       Debug.Log(diceNumber+ " has been rolled!");
    }
}
