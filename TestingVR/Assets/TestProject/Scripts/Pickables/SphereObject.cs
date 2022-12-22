using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereObject : MonoBehaviour
{
    [SerializeField] private GameObject infoTextObject;
    public void OnSphereDropped()
    {
        if (infoTextObject) infoTextObject.SetActive(false);
    }
}
