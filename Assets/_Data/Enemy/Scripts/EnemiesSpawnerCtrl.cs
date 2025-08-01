using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnerCtrl : SaiSingleton<EnemiesSpawnerCtrl>
{
    [SerializeField] protected EnemiesSpawner spawner;
    public EnemiesSpawner Spawner => spawner;

    [SerializeField] protected SpawnPointCtrl spawnPointCtrl;
    public SpawnPointCtrl SpawnPointCtrl => spawnPointCtrl; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPointCtrl();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.GetComponent<EnemiesSpawner>();
        Debug.LogWarning(transform.name + ":EnemiesSpawner", gameObject);
    }

    protected virtual void LoadSpawnPointCtrl()
    {
        if (this.spawnPointCtrl != null) return;
        this.spawnPointCtrl = transform.GetComponentInChildren<SpawnPointCtrl>();
        Debug.LogWarning(transform.name + ":SpawnPointCtrl", gameObject);
    }
}
