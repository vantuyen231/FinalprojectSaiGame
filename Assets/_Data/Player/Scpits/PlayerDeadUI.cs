using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadUI : SaiSingleton<PlayerDeadUI>
{
    [SerializeField] protected Transform showHide;

    protected bool isShow = true;
    protected bool IsShow => isShow;

    protected override void Start()
    {
        base.Start();
        this.Hide();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowHide();
    }

    protected virtual void LoadShowHide()
    {
        if (showHide != null) return;
        this.showHide = transform.Find("ShowHide");
        Debug.Log(transform.name + ": LoadShowHide", gameObject);
    }

    public virtual void Show()
    {
        this.isShow = true;
        this.showHide.gameObject.SetActive(this.isShow);
    }

    public virtual void Hide()
    {
        this.showHide.gameObject.SetActive(false);
        this.isShow = false;
    }
}
