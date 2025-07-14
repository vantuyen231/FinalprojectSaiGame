using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : SaiBehavior
{
    //[SerializeField] protected Transform targetToMove;
    [SerializeField] protected Point pointToGo;
    public Point PointToGo => pointToGo;
    [SerializeField] protected EnemyCtrl ctrl;
    [SerializeField] protected bool IsWalking = true;
    [SerializeField] protected bool IsIdle = true;
    [SerializeField] protected bool IsAttack = true;
    [SerializeField] protected float stopDistanceAttack = 1.5f;
    [SerializeField] protected float targetDistance = 0f;
    [SerializeField] protected float stopDistance = 2f;
    [SerializeField] protected bool isReachTarget = false;





    protected virtual void FixedUpdate()
    {
        this.MoveToTarget();
        this.UpdateAnimator();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        //this.LoadTarget();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.ctrl != null)
        {
            return;
        }
        this.ctrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ":LoadEnemyCtrl", gameObject);

        this.ctrl.Agent.stoppingDistance = this.stopDistanceAttack;

    }

    //protected virtual void LoadTarget()
    //{
    //    if (this.targetToMove != null)
    //    {
    //        return;
    //    }
    //    this.targetToMove = GameObject.Find("TargetToMove").transform;
    //    Debug.LogWarning(transform.name + ":LoadTarget", gameObject);
    //}

    protected virtual void MoveToTarget()
    {
        if (!this.CanMove())
        {
            this.StopMoving();
            return;
        }
        Vector3 postion = this.pointToGo.transform.position;

        this.targetDistance = Vector3.Distance(transform.position,  this.pointToGo.transform.position);
        if (this.targetDistance <= this.stopDistance)
        {
            this.ctrl.Agent.isStopped = true;
            this.ctrl.Agent.SetDestination(postion);

        }
        else
        {
            this.ctrl.Agent.isStopped = false;
            this.ctrl.Agent.SetDestination(postion);
        }
        //this.ctrl.Agent.SetDestination(postion);
    }

    protected virtual void UpdateAnimator()
    {
        this.IsWalking = !this.ctrl.Agent.isStopped;
        this.ctrl.Animator.SetBool("IsWalking", this.IsWalking);


        //this.IsIdle = !this.IsWalking && !this.IsAttack;
        //this.ctrl.Animator.SetBool("Idle", this.IsIdle);

        this.UpdateAttackState();


    }
    protected virtual void UpdateAttackState()
    {
        if (this.targetDistance < this.stopDistanceAttack)
        {
            this.IsAttack = true;
        }
        else
        {
            this.IsAttack = false;
        }

        this.ctrl.Animator.SetBool("IsAttack", this.IsAttack);
    }

    protected virtual bool CanMove()
    {
        bool canMove = true;
        if (this.pointToGo == null) canMove = false;
        if (this.ctrl.DamageReceiver != null && !this.ctrl.DamageReceiver.IsAlive()) canMove = false;

        return canMove;
    }

    protected virtual void StopMoving()
    {
        this.ctrl.Agent.isStopped = true;
    }
}
