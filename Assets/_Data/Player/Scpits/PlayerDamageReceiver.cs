using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected PlayerCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
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
        Debug.Log("Player is Dead");
    }
}
