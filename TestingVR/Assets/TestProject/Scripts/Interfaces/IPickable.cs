using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    void OnHover();
    void OnHoverLeft();
    void OnPickup();
    void OnDrop(Vector3 linearVelocity, Vector3 angularVelocity);
}
