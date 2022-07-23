using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titik : MonoBehaviour
{
    public int titik_ID;
    public bool bonusMaju;
    List<PlayerMovement> playerList = new List<PlayerMovement>();
    // Start is called before the first frame update
    public void SetTitikId(int _titikID) 
    {
        titik_ID = _titikID;
    }

    public void AddPlayer(PlayerMovement player) 
    {
        playerList.Add(player);

        //Atur Posisi
        ReArrangePlayer();
    }

    public void RemovePlayer(PlayerMovement player)
    {
        playerList.Remove(player);

        //Atur Posisi
        ReArrangePlayer();
    }

    void ReArrangePlayer()
    {
        if (playerList.Count > 1)
        {
            int hexasize = Mathf.CeilToInt(Mathf.Sqrt(playerList.Count));
            int player = -1;
            for (int x = 0; x < hexasize; x++) 
            {
                for (int y = 0; y < hexasize; y++)
                {
                    player++;
                    if (player>playerList.Count-1) 
                    {
                        break;
                    }
                    Vector3 newPos = transform.position + new Vector3(-0.005f+x*0.03f, 0, -0.02f+y * 0.03f);
                    playerList[player].transform.position = newPos;
                }
            }
        }
        else if (playerList.Count == 1)
        {
            playerList[0].transform.position = transform.position;
        }
    }

}
