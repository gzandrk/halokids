using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SideCheck : MonoBehaviour
{
	public Dadu dadu;

	public int diceNumber;

	bool onGround;

	// Update is called once per frame
	void Update()
	{
		
	}

	void OnTriggerStay(Collider col)
	{
		if (GameObject.FindGameObjectWithTag("dice").gameObject.GetComponent<Rigidbody>().velocity.magnitude == 0)
		{
			if (col.gameObject.CompareTag("Ground"))
			{
				onGround = true;
			}

			switch (col.gameObject.name)
			{
				case "1":
					diceNumber = 5;
					break;
				case "2":
					diceNumber = 3;
					break;
				case "3":
					diceNumber = 2;
					break;
				case "4":
					diceNumber = 6;
					break;
				case "5":
					diceNumber = 1;
					break;
				case "6":
					diceNumber = 4;
					break;
			}
			print("angka dadu "+diceNumber);
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
