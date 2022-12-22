using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private LaserPointer laserPointer;
    public void ToggleRayForUIInteraction()
    {
        laserPointer.gameObject.SetActive(!laserPointer.isActiveAndEnabled);
    }
    public void OpenMainUI()
    {
        gameObject.SetActive(true);
        ToggleRayForUIInteraction();
    }
    public void HideMainUI()
    {
        gameObject.SetActive(false);
        ToggleRayForUIInteraction();
    }
}
