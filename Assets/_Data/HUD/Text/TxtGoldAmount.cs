using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtGoldAmount : TextAbstact
{
    protected virtual void FixedUpdate()
    {
        this.LoadGoldCount();
    }

    protected virtual void LoadGoldCount()
    {
        ItemInventory item = InventoryManager.Instance.Monies().FindItem(ItemCode.Gold);
        string goldCount;
        if (item == null) goldCount = "0";
        else goldCount = item.itemCount.ToString();
        this.textPro.text = goldCount;
    }
}