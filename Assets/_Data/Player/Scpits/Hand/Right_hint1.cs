using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Right_hint1 : SaiBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.38f, 0.245f, 0.172f);
        transform.localRotation = Quaternion.Euler(85.329f, 0.012f, -89.988f);
    }
}
