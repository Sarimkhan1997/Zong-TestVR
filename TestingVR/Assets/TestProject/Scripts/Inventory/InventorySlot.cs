using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private GameObject itemInSlot;
    [SerializeField] private Image icon;
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI titleText;
    
    private Color originalColor;

    private void Awake()
    {
        originalColor = slotImage.color;
    }
    private void OnTriggerStay(Collider other)
    {
        if (itemInSlot != null || !IsPickableItem(other.gameObject)) return;

        print("Entering Slot: " + other.gameObject);
        AddItem(other.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (itemInSlot == null || !IsPickableItem(other.gameObject)) return;

            print("Exiting Slot: " + other.gameObject);

        if (other.GetComponent<Pickable>().item.inSlot)
            ClearSlot(other.gameObject);
    }
    private bool IsPickableItem(GameObject other)
    {
        return other.GetComponent<Pickable>();
    }
    private void AddItem(GameObject obj)
    {
        InventoryItem item = obj.GetComponent<Pickable>().item;
        Inventory.Instance.AddItem(item);
        EventsManager.onCheckpointReached?.Invoke(1);

        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        //obj.GetComponent<MeshRenderer>().enabled = false;
        //icon.gameObject.SetActive(true);
        //icon.sprite = item.icon;
        item.inSlot = true;
        itemInSlot = obj;
        titleText.text = item.name;
        slotImage.color = Color.gray;
    }
    private void ClearSlot(GameObject obj)
    {
        InventoryItem item = obj.GetComponent<Pickable>().item;
        Inventory.Instance.RemoveItem(item);
        slotImage.color = originalColor;
        itemInSlot = null;
        titleText.text = "";
        icon.gameObject.SetActive(false);
        EventsManager.onItemUsed?.Invoke();
    }
}
