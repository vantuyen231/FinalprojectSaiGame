using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    [SerializeField] protected EnemyCtrl ctrl;

    protected virtual void LateUpdate()
    {
        this.UpdateDeadAnimation();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected virtual void UpdateDeadAnimation()
    {
        this.ctrl.Animator.SetBool("IsAlive", this.isAlive);
    }
    protected override void Reborn()
    {
        base.Reborn(); 
        this.isAlive = true;

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = true;

        this.ctrl.Animator.SetBool("IsAlive", true);
        this.ctrl.ResetModelRotation();

    }
    public override void IsHit()
    {
        //this.ctrl.Animator.SetTrigger("IsHit");
    }

    protected override void OnDead()
    {
        base.OnDead();
        //this.DropItems();
        Invoke(nameof(this.Despawn), 12f);
    }

    //protected override void OnDead()
    //{
    //    this.ctrl.Animator.SetBool("IsAlive", false);

    //    Collider col = GetComponent<Collider>();
    //    if (col != null) col.enabled = false;

    //    Invoke(nameof(DespawnEnemy), 5f);
    //}

    //protected virtual void DespawnEnemy()
    //{
    //    EnemiesSpawnerCtrl.Instance.Spawner.Despawn(this.ctrl);
    //}
    protected virtual void Despawn()
    {
        this.ctrl.Despawn.DoDespawn();
    }
}
