using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnerCtrl : SaiBehaviour
{
    [SerializeField] protected List<TurretCtrl> turretCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTurretCtrl();
    }

    protected virtual void LoadTurretCtrl()
    {
        if (this.turretCtrl.Count > 0) return;
        TurretCtrl[] turrets = transform.GetComponentsInChildren<TurretCtrl>();
        this.turretCtrl = new List<TurretCtrl>(turrets);
        Debug.Log(transform.name + ": LoadFirePoints", gameObject);
    }
}
