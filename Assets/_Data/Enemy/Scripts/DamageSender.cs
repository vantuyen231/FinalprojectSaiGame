using UnityEngine;
using UnityEngine.EventSystems;

public abstract  class DamageSender : SaiBehavior
{
    [SerializeField] protected int damage = 1;

    public virtual int GetDamage()
    {
        return this.damage;
    }
    public abstract void Despawn();

}