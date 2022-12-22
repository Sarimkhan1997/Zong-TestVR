using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item" , menuName = "Inventory/PickableItem")]
public class InventoryItem : ScriptableObject
{
    new public string name = "New Item";
    public string description = "Sample description";
    public Sprite icon;
    public bool inSlot;
}
