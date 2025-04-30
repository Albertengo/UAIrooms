using UnityEngine;

/// <summary>
/// Attached to the non-player characters, and stores the name of the Yarn
/// node that should be run when you talk to them.
/// </summary>S
public class NPC : MonoBehaviour
{
    public string characterName = "";

    public string talkToNode = "";
}
