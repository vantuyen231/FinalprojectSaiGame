using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : SaiBehaviour
{
    [SerializeField] protected TurretCtrl ctrl;
    [SerializeField] protected Targetable target;
    [SerializeField] protected float rotationSpeed = 4f;
    [SerializeField] protected float shootSpeed = 1f;
    [SerializeField] protected int currentFirePoint = 0;

    public BulletCtrl bulletPrefab;



    protected override void Start()
    {
        base.Start();
        this.TargetLoading();
        this.Shooting();
    }

    protected virtual void FixedUpdate()
    {
        this.Looking();
    }

    protected virtual void Looking()
    {
        if (this.target == null) return;
        Vector3 directionToTarget = this.target.transform.position - this.ctrl.Rotator.position-Vector3.up * 1.0f;
        Vector3 newDirection = Vector3.RotateTowards(
            this.ctrl.Rotator.forward, directionToTarget, rotationSpeed * Time.deltaTime, 0.0f);
        this.ctrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoandTurretCtrl();
    }

    protected virtual void LoandTurretCtrl()
    {
        if(this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<TurretCtrl>();
        Debug.Log(transform.name + ": LoadTurretCtrl",gameObject);
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading),1f); 
        this.target = this.ctrl.TurretTargeting.Nearest;
    }

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), this.shootSpeed + Random.Range(-0.1f, 0.1f));

        if (this.target == null) return;
        Debug.Log("Shooting");
        FirePoint firePoint = this.GetFirePoint();

        Vector3 rotarionDirection = this.ctrl.Rotator.transform.forward;

        //Transform newBullet = Instantiate(this.bulletPrefab, firePoint.transform.position, Quaternion.identity);
        //newBullet.rotation = Quaternion.LookRotation(rotarionDirection.normalized);

        BulletCtrl newBullet = BulletSpawnerCtrl.Instance.Spawner.Spawn(this.bulletPrefab, firePoint.transform.position);
        newBullet.transform.rotation = Quaternion.LookRotation(rotarionDirection.normalized);

        newBullet.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.ctrl.FirePoints[this.currentFirePoint];
        this.currentFirePoint++;
        if(this.currentFirePoint == this.ctrl.FirePoints.Count) this.currentFirePoint = 0;
        return firePoint;
    }
}
