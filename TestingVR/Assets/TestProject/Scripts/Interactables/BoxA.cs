using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxA : Box
{
    public override void Interact()
    {
        base.Interact();
        print("Interacting Box A");
    }
}
