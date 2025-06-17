using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class SaveSystem 

{
    static string path = Application.persistentDataPath + "/playerdata.json";

    public static void SavePlayer(PlayerMovement player, Sanity sanityScript, UAIcoins coinManager)
    {
        PlayerData data = new PlayerData(player, sanityScript, coinManager);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        Debug.Log("Guardado en: " + path);
    }

    public static void LoadPlayer(PlayerMovement player, Sanity sanityScript, UAIcoins coinManager)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

           
            player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);


            coinManager.coins = data.coins;
            sanityScript.sanity = data.sanity;
        }
        else
        {
            Debug.LogWarning("No se encontró archivo de guardado");
        }
    }
}

 
    

