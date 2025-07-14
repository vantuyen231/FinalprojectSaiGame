using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawning : SaiBehavior
{
    [SerializeField] protected EnemiesSpawnerCtrl ctrl;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 5;

    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponent<EnemiesSpawnerCtrl>();
        Debug.LogWarning(transform.name + ":EnemiesSpawnerCtrl", gameObject);
    }

    protected virtual void Spawning()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        EnemyCtrl enemyPrefabs = this.ctrl.Spawner.PoolPrefabs.GetByName("Pink");
        EnemyCtrl newEnemy = this.ctrl.Spawner.Spawn(enemyPrefabs);
        newEnemy.SetActive(true);
    }
}
