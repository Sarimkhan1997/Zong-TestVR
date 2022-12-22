using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsManager
{
    public delegate void OnResetState();
    public static OnResetState onResetState;

    public delegate void OnCheckpointReached(int id);
    public static OnCheckpointReached onCheckpointReached;

    public delegate void OnItemPickup();
    public static OnItemPickup onItemPickup;

    public delegate void OnItemUsed();
    public static OnItemUsed onItemUsed;
}
