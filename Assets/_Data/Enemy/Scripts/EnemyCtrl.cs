using UnityEngine;
using UnityEngine.AI;


public class EnemyCtrl : PoolObj
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Animator animator;
    [SerializeField] protected DamageReceiver damageReceiver;


    public NavMeshAgent Agent => agent;
    public Animator Animator => animator;

    public DamageReceiver DamageReceiver => damageReceiver;

    int currentHp = 10;
    public float weight = 1f;
    //string enemyName = "";

    protected override void Awake()
    {
        base.Awake();
        this.RandomWeight();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAgent();
        this.LoadAnimator();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadAgent()
    {
        if (this.agent != null)
        {
            return;
        }
        this.agent = this.GetComponent<NavMeshAgent>();
        Debug.LogWarning(transform.name + ":LoadAgent", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null)
        {
            return;
        }
        this.damageReceiver = this.GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ":LoadDamageReceiver", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null)
        {
            return;
        }
        this.animator = this.transform.Find("Model").GetComponent<Animator>();
        Debug.LogWarning(transform.name + ":LoadAnimator", gameObject);
    }

    bool IsDead()
    {
        if (this.currentHp > 0) return false;
        else return true;
    }

    bool IsAlive()
    {
        return this.currentHp > 0;
    }

    int GetCurrenHp()
    {
        return this.currentHp;
    }

    void RandomWeight()
    {
        this.weight = UnityEngine.Random.Range(0.5f, 4f);
    }

    public override string GetName()
    {
        return "Enemy";
    }
}