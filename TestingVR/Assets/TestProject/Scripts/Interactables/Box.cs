using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Box : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameObject VFX;

    private AudioSource SFXsource;

    private void Awake()
    {
        SFXsource = GetComponent<AudioSource>();
    }
    public virtual void Interact()
    {
        if (VFX) VFX.SetActive(true);

        PlaySFX();
        EventsManager.onCheckpointReached?.Invoke(2);
    }
    private void PlaySFX()
    {
        SFXsource?.Play();
    }
}
