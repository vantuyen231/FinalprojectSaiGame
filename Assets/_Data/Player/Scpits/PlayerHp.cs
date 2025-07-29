using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : SliderHp
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.FindAnyObjectByType<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected override float GetValue()
    {
        if (this.playerCtrl.PlayerReceiver == null) return 1;

        return (float)this.playerCtrl.PlayerReceiver.CurrentHp / (float)this.playerCtrl.PlayerReceiver.MaxHp;
    }
}
