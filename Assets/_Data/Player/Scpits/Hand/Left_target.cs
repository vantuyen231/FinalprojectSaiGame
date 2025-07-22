using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left_target : SaiBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.1022f, 0.4396f, 0.407f);
        transform.localRotation = Quaternion.Euler(-23.849f, 86.176f, 112.927f);
    }
}
