using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDamageReceiver : DamageReceiver
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
        this.ctrl = transform.parent.GetComponent<TurretCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override void Reborn()
    {
        base.Reborn();
        this.isAlive = true;
        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = true;

        //this.ctrl.Animator.SetBool("IsAlive", true);

    }

    protected override void OnDead()
    {
        base.OnDead();
        //this.
        Debug.Log("Turret is Dead");
    }
}
