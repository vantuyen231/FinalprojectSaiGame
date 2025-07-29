using UnityEngine;
using UnityEngine.EventSystems;

public abstract  class DamageSender : SaiBehaviour
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected Faction senderFaction;

    public virtual int GetDamage()
    {
        return this.damage;
    }

    public virtual Faction GetFaction()
    {
        return this.senderFaction;
    }

    public abstract void Despawn();

}