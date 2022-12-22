using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickable : MonoBehaviour, IPickable
{
    public InventoryItem item;

    #region Unity_Events
    public UnityEvent OnPicked;
    public UnityEvent OnDropped;
    #endregion

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnDrop(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        print("Dropped: " + item.name);
        rb.isKinematic = false;
        rb.useGravity = true;

        rb.velocity = linearVelocity;
        transform.parent = null;
        OnDropped?.Invoke();
    }

    public void OnHover()
    {
        print("Hovered: " + item.name);
    }

    public void OnHoverLeft()
    {
        print("Hovered Left: " + item.name);
    }
    public void OnPickup()
    {
        print("Picked up: " + item.name);
        EventsManager.onItemPickup?.Invoke();
        rb.isKinematic = true;
        rb.useGravity = false;
        OnPicked?.Invoke();
    }
    private void OnCollisionEnter(Collision collision)
    {
        IInteractable interactable = collision.collider.GetComponent<IInteractable>();
        if (interactable == null) return;

        interactable.Interact();
    }
}
