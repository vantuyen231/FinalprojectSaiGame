using UnityEngine;
using UnityEngine.AI;

public class EnemyHp : SliderHp
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override float GetValue()
    {
        if (this.enemyCtrl.DamageReceiver == null) return 1;

        return (float)this.enemyCtrl.DamageReceiver.CurrentHp / (float)this.enemyCtrl.DamageReceiver.MaxHp;
    }
}