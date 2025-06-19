using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Yarn.Unity.ActionAnalyser;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject 
{
    [Header("Only Gameplay")]
    [SerializeField] TileBase tile;
    [SerializeField] ItemType type;
    [SerializeField] ActionType actionType;
    [SerializeField] Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    [SerializeField] bool stackable = true;

    [Header("Both")]
    public Sprite image;
}
public enum ItemType
{
    BuildingBlock,
    Tool
}

public enum ActionTyoe
{
    Dig,
    Mine
}