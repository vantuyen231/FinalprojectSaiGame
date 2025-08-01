using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawning : SaiBehaviour
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
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponent<EnemiesSpawnerCtrl>();
        Debug.Log(transform.name + ":LoadCtrl", gameObject);
    }

    protected virtual void Spawning()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        //EnemyCtrl enemyPrefabs = this.ctrl.Spawner.PoolPrefabs.GetByName("Pink");
        //EnemyCtrl newEnemy = this.ctrl.Spawner.Spawn(enemyPrefabs);
        //newEnemy.transform.position = transform.position;
        //newEnemy.SetActive(true);
        EnemyCtrl enemyPrefab = this.ctrl.Spawner.PoolPrefabs.GetByName("Pink");

        List<SpawnPoint> spawnPoints = EnemiesSpawnerCtrl.Instance.SpawnPointCtrl.SpawnPoints;
        if (spawnPoints.Count == 0) return;

        SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        EnemyCtrl newEnemy = this.ctrl.Spawner.Spawn(enemyPrefab);
        newEnemy.transform.position = spawnPoint.transform.position;
        newEnemy.transform.rotation = spawnPoint.transform.rotation; // neu can
        newEnemy.SetActive(true);
    }
}
