using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : Singleton<SoundsManager>
{
    [SerializeField] private GameObject SFX;

    public GameObject GetSFXObject()
    {
        return SFX;
    }
    protected override void Awake()
    {
        base.Awake();
    }
}
