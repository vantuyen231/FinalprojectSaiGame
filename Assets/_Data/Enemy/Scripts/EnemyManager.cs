using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SaiBehavior
{
    public List<EnemyCtrl> enemies;
    public EnemyCtrl minEnemy;
    public EnemyCtrl maxEnemy;

    protected override void Start()
    {
        this.ShowEnemy();
        this.FindMinMaxEnemy(); 
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemies();
    }

    protected virtual void LoadEnemies()
    {
        if(this.enemies.Count > 0) return;
        EnemyCtrl enemyCtrl;
        foreach(Transform child in transform)
        {
            enemyCtrl =  child.GetComponent<EnemyCtrl>();
            this.enemies.Add(enemyCtrl);
        }
        Debug.LogWarning(transform.name + ": LoadEnemies ", gameObject);
    }

    void ShowEnemy()
    {
        foreach(EnemyCtrl enemy in enemies)
        {
            Debug.Log(enemy.name + ": " + enemy.weight);
        }
    }

    void FindMinMaxEnemy()
    {
        float minEnemy = Mathf.Infinity;
        float maxEnemy = 0;
        foreach (EnemyCtrl enemy in enemies)
        {
            if(enemy.weight < minEnemy)
            {
                minEnemy = enemy.weight;
                this.minEnemy = enemy;
            }
            if(enemy.weight >= maxEnemy)
            {
                maxEnemy = enemy.weight;
                this.maxEnemy = enemy;
            }
        }

        //Debug.Log("Min Enemy: "+ this.minEnemy +" Weight"+this.minEnemy.weight);
        //Debug.Log("Max Enemy " + this.maxEnemy + " Weight " + this.maxEnemy.weight);

    }
}
