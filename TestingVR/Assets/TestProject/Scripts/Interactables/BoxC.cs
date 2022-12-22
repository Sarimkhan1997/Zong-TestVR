using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxC : Box
{
    public override void Interact()
    {
        base.Interact();
        print("Interacting Box C");

        EventsManager.onResetState?.Invoke();
    }
}
