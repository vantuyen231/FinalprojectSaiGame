using com.cyborgAssets.inspectorButtonPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTester : SaiBehavior
{
    protected override void Start()
    {
        base.Start();
        this.AddTestItems(ItemCode.Gold, 1000);
        this.AddTestItems(ItemCode.Gun, 10);
    }

    [ProButton]
    public virtual void AddTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoryManager.Instance.AddItem(itemCode, 1);
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoryManager.Instance.RemoveItem(itemCode, 1);
        }
    }
}