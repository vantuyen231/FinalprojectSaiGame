using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnerCtrl : SaiSingleton<EnemiesSpawnerCtrl>
{
    [SerializeField] protected EnemiesSpawner spawner;
    public EnemiesSpawner Spawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.GetComponent<EnemiesSpawner>();
        Debug.LogWarning(transform.name + ":EnemiesSpawner", gameObject);
    }
}
