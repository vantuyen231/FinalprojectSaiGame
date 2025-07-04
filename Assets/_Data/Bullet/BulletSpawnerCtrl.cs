using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletSpawnerCtrl : SaiSingleton<BulletSpawnerCtrl>
{
    [SerializeField] protected BulletSpawner spawner;
    public BulletSpawner Spawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null)
        {
            return;
        }
        this.spawner = transform.GetComponent<BulletSpawner>();
        Debug.LogWarning(transform.name + ":LoadEnemyCtrl", gameObject);
    }
}
