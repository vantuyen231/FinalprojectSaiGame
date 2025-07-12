using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Right_target : SaiBehavior
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.16f, 0.386f, 0.279f);
        transform.localRotation = Quaternion.Euler(2.49f, -87.717f, -105.526f);
    }
}

