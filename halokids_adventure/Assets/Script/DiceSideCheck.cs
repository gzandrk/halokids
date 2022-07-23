using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideCheck : MonoBehaviour
{
    bool onGround;
    public int diceNumber;

    // Update is called once per frame

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    public bool OnGround()
    {
        return onGround;
    }
}
