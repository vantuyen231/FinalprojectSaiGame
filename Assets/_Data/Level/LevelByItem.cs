using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
    [SerializeField] protected ItemInventory playerExp;

    protected override int GetCurrentExp()
    {
        if (this.GetPlayerExp() == null) return 0;
        return this.GetPlayerExp().itemCount;
    }

    protected virtual ItemInventory GetPlayerExp()
    {
        if (this.playerExp == null || this.playerExp.ItemID == 0) this.playerExp = InventoryManager.Instance.Monies().FindItem(ItemCode.PlayerExp);
        return this.playerExp;
    }
}