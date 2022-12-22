using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    protected override void Awake()
    {
        base.Awake();
    }
    public void AddItem(InventoryItem item)
    {
        if (!inventoryItems.Contains(item))
            inventoryItems.Add(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback();
    }
    public void RemoveItem(InventoryItem item)
    {
        if (inventoryItems.Contains(item))
            inventoryItems.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback();
    }
}

