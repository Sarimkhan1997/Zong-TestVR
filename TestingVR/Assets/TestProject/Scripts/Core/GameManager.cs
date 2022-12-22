using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MainUI mainUI;
    [SerializeField] private Transform playerTransform;


    private void OnEnable()
    {
        mainUI.ToggleRayForUIInteraction();
        EventsManager.onResetState += ResetGameState;
        //EventsManager.onItemPickup += OpenMainUI;
        //EventsManager.onItemUsed += CloseMainUI;
    }
    private void OnDestroy()
    {
        EventsManager.onResetState -= ResetGameState;
        //EventsManager.onItemPickup -= OpenMainUI;
        //EventsManager.onItemUsed -= CloseMainUI;
    }

    private void ResetGameState()
    {
        print("Resetting state...");
        //OpenMainUI();
        SceneManager.LoadScene(0);
    }
    private void OpenMainUI()
    {
        mainUI.transform.position = playerTransform.position + playerTransform.forward * 1.5f;
        mainUI.OpenMainUI();
    }
    private void CloseMainUI()
    {
        mainUI.HideMainUI();
    }
}

