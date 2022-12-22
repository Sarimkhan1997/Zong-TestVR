using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxB : Box
{
    public override void Interact()
    {
        base.Interact();

        print("Interacting Box B");
    }
}
