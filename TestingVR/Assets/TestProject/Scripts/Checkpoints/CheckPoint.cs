using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Checkpoints/Checkpoint")]
public class CheckPoint : ScriptableObject
{
    public string title = "New Title";
    public bool isCompleted = false;
    public int id = 0;

    public Action OnCheckpointCompleted;
}
