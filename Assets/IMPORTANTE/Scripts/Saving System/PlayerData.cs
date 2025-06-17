using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{

    public int sanity;
    public float[] position;
    public int coins;
    //public List<string> items;

    public void SaveToJson()
    {

        //string playerData = JsonUtility.ToJson(this);

    }

    public PlayerData(PlayerMovement player, Sanity sanityScript, UAIcoins UAIcoins/* List<string> items*/)
    {


        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        coins = UAIcoins.coins;
        sanity = sanityScript.sanity;


        //items = inventoryManager.items;
    }

}
