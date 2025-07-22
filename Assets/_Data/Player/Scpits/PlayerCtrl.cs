using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCtrl : SaiSingleton<PlayerCtrl>
{
    [SerializeField] protected WeaponsCtrl weaponsCtrl;
    public WeaponsCtrl WeaponsCtrl => weaponsCtrl;


    [SerializeField] protected vThirdPersonCamera thirdPersonCamera;
    public vThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;

    [SerializeField] protected vThirdPersonController thirdPersonCtrl;
    public vThirdPersonController ThirdPersonController => thirdPersonCtrl;

    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;

    [SerializeField] protected Rig aimingRig;
    public Rig AimingRig => aimingRig;

    [SerializeField] protected PlayerLevel level;
    public PlayerLevel Level => level;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThirdPersonCtrl();
        this.LoadThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LoadWeapons();
        this.LoadAimingRig();
        this.LoadLevel();
    }

    protected virtual void LoadLevel()
    {
        if (this.level != null) return;
        this.level = GetComponentInChildren<PlayerLevel>();
        Debug.Log(transform.name + ": LoadLevel", gameObject);
    }

    protected virtual void LoadWeapons()
    {
        if (this.weaponsCtrl != null) return;
        this.weaponsCtrl = GetComponentInChildren<WeaponsCtrl>();
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    protected virtual void LoadThirdPersonCtrl()
    {
        if (this.thirdPersonCtrl != null) return;
        this.thirdPersonCtrl = GetComponentInChildren<vThirdPersonController>();
        Debug.Log(transform.name + ": LoadThirPersonCtrl", gameObject);
    }

    protected virtual void LoadCrosshairPointer()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = GetComponentInChildren<CrosshairPointer>();
        Debug.Log(transform.name + ": LoadCrosshairPointer", gameObject);
    }

    protected virtual void LoadThirdPersonCamera()
    {
        if (this.thirdPersonCamera != null) return;
        this.thirdPersonCamera = GameObject.FindAnyObjectByType<vThirdPersonCamera>();
        this.thirdPersonCamera.rightOffset = 0.6f;
        this.thirdPersonCamera.defaultDistance = 1.2f;
        this.thirdPersonCamera.height = 1.3f;
        this.thirdPersonCamera.yMinLimit = -40f;
        this.thirdPersonCamera.yMaxLimit = 40f;
        Debug.Log(transform.name + ": LoadThirdPersonCamera", gameObject);
    }

    //protected virtual void LoadAimingRig()
    //{
    //    if (this.aimingRig != null) return;
    //    this.aimingRig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();
    //    Debug.Log(transform.name + ": LoadAimingRig", gameObject);
    //}

    protected virtual void LoadAimingRig()
    {
        if (this.aimingRig != null) return;

        this.aimingRig = transform.Find("Model").Find("mixamorig1:Hips").Find("AimingRig").GetComponent<Rig>();
        Debug.Log(transform.name + ": LoadAimingRig", gameObject);
    }
}