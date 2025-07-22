using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left_hint : SaiBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(-0.1367f, 0.3519f, 0.2272f);
        transform.localRotation = Quaternion.Euler(90.51401f, 17.726f, 107.554f);
    }
}