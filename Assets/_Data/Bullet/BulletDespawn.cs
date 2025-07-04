using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnBase
{
    [SerializeField] protected BulletCtrl ctrl;
    [SerializeField] protected float delay = 7;

    private void OnEnable()
    {
        Invoke(nameof(DoDespawn), delay);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ":LoadCtrl", gameObject);
    }

    public override void DoDespawn()
    {
        BulletSpawnerCtrl.Instance.Spawner.Despawn(this.ctrl);
    }
}
