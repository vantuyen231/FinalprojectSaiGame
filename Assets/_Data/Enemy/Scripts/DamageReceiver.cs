using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamageReceiver : SaiBehavior
{
    [Header("Damage Receiver")]
    [SerializeField] protected int currentHp = 10;
    public int CurrentHp => currentHp;
    [SerializeField] protected int maxHp = 7;
    public int MaxHp => maxHp;
    [SerializeField] protected bool isAlive = true;

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    protected virtual void OnTriggerEnter(Collider trigger)
    {
        this.ApplyDamage(trigger);
    }

    protected virtual void ApplyDamage(Collider trigger)
    {
        if (!this.IsAlive()) return;
        DamageSender damageSender = trigger.GetComponent<DamageSender>();
        //damageSender = trigger.GetComponent<DamageSender>();
        //BulletDamageSender damageSender = trigger.GetComponent<BulletDamageSender>();
        if (damageSender == null) return;
        damageSender.Despawn();
        this.Deduct(damageSender.GetDamage());
        this.IsHit();
        if (!this.IsAlive())
        {
            this.OnDead();
        }
    }

    public virtual void Deduct(int damage)
    {
        this.currentHp -= damage;
        if (this.currentHp < 0) this.currentHp = 0;
    }

    protected virtual void Reborn()
    {
        this.currentHp = this.maxHp;
    }

    public virtual bool IsAlive()
    {
        if (this.currentHp <= 0)
        {
            this.isAlive = false;
            //this.OnDead();
        }
        else this.isAlive = true;
        return this.isAlive;
    }
    public virtual void IsHit()
    {

    }
    protected virtual void OnDead()
    {

    }
}