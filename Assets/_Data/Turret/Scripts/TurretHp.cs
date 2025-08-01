using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHp : SliderHp
{
    [SerializeField] protected TurretCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTurretCtrl();
    }
    protected virtual void LoadTurretCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<TurretCtrl>();
        Debug.Log(transform.name + ": LoadTurretCtrl", gameObject);
    }

    protected override float GetValue()
    {
        if (this.ctrl.TurretDamageReceiver == null) return 1;

        return (float)this.ctrl.TurretDamageReceiver.CurrentHp / (float)this.ctrl.TurretDamageReceiver.MaxHp;
    }
}
