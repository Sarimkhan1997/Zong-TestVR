using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrabber : MonoBehaviour
{
    [SerializeField]
    protected OVRInput.Controller controller;

    [SerializeField]
    protected Collider[] grabVolumes = null;

    public float grabBegin = 0.55f;
    public float grabEnd = 0.35f;

    public HandType handType;
    public Transform parentTransform;
    public IPickable pickableObject = null;
    public IPickable hoveredObject = null;

    public List<Pickable> objectsInGrabArea = new List<Pickable>();
    private GameObject pickedObject = null;
    private GameObject objectPicked = null;
    private float rightTrigger = 0f;

    private float m_prevFlex = 0;

    private void Update()
    {
        float prevFlex = m_prevFlex;
        m_prevFlex = OVRInput.Get(handType == HandType.Left ? OVRInput.Axis1D.PrimaryHandTrigger : OVRInput.Axis1D.SecondaryHandTrigger);
        CheckForGrabOrRelease(prevFlex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (objectPicked != null) return;

        Pickable pickable = other.GetComponent<Pickable>();
        if (pickable != null)
        {
            if (!objectsInGrabArea.Contains(pickable))
                objectsInGrabArea.Add(pickable);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (objectPicked == null) return;

        Pickable pickable = other.GetComponent<Pickable>();
        if (pickable != null)
        {
            if (objectsInGrabArea.Contains(pickable))
                objectsInGrabArea.Remove(pickable);
        }
    }

    private void ToggleGrabVolumes(bool toggle)
    {
        for (int i = 0; i < grabVolumes.Length; ++i)
        {
            Collider grabVolume = grabVolumes[i];
            grabVolume.enabled = toggle;
        }
    }
    protected void CheckForGrabOrRelease(float prevFlex)
    {
        if ((m_prevFlex >= grabBegin) && (prevFlex < grabBegin))
        {
            GrabBegin();
        }
        else if ((m_prevFlex <= grabEnd) && (prevFlex > grabEnd))
        {
            GrabEnd();
        }
    }
    private void GrabBegin()
    {
        float closestMagSq = float.MaxValue;
        Pickable closestGrabbable = null;

        foreach (var grabbable in objectsInGrabArea)
        {
            Collider grabbableCollider = grabbable.GetComponent<Collider>();

            Vector3 closestPointOnBounds = grabbableCollider.ClosestPointOnBounds(parentTransform.position);
            float grabbableMagSq = (parentTransform.position - closestPointOnBounds).sqrMagnitude;
            if (grabbableMagSq < closestMagSq)
            {
                closestMagSq = grabbableMagSq;
                closestGrabbable = grabbable;
            }
        }

        if (closestGrabbable == null) return;

        if (closestGrabbable.item.inSlot)
        {
            closestGrabbable.GetComponent<MeshRenderer>().enabled = true;
            closestGrabbable.transform.parent = null;
        }
            objectPicked = closestGrabbable.gameObject;
        objectPicked.transform.parent = parentTransform;

        closestGrabbable.OnPickup();  
    }
    private void GrabEnd()
    {
        if (objectPicked != null)
        {
            OVRPose localPose = new OVRPose { position = OVRInput.GetLocalControllerPosition(controller), orientation = OVRInput.GetLocalControllerRotation(controller) };

            OVRPose trackingSpace = transform.ToOVRPose() * localPose.Inverse();
            Vector3 linearVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerVelocity(controller);
            Vector3 angularVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerAngularVelocity(controller);

            //GrabbableRelease(linearVelocity, angularVelocity);
            //objectPicked.GetComponent<Pickable>().OnDrop(linearVelocity, angularVelocity);
            objectPicked.GetComponent<Pickable>().OnDrop(OVRInput.GetLocalControllerVelocity(controller), angularVelocity);
            objectsInGrabArea.Clear();
            objectPicked = null;
        }

        // Re-enable grab volumes to allow overlap events
        ToggleGrabVolumes(true);
    }
}

public enum HandType
{
    Right,
    Left
}
