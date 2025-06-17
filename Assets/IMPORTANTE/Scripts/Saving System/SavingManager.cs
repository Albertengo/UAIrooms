using UnityEngine;

public class SavingManager : MonoBehaviour
{
    public PlayerMovement player;
    public UAIcoins coinManager;
    public Sanity sanityScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveSystem.SavePlayer(player, sanityScript, coinManager);
            Debug.Log("partida guardada");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SaveSystem.LoadPlayer(player, sanityScript, coinManager);
            Debug.Log("partida cargada");
        }
    }
}
