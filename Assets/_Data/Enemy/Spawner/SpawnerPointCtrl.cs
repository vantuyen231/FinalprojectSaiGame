using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPointCtrl : SaiBehavior
{
    [SerializeField] protected SpawnerPointCtrl spawnpoint;
    public SpawnerPointCtrl Spawnpoint => spawnpoint;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }
    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnpoint != null) return;
        this.spawnpoint = transform.GetComponent<SpawnerPointCtrl>();
        Debug.LogWarning(transform.name + ":SpawnerPointCtrl", gameObject);
    }
}
