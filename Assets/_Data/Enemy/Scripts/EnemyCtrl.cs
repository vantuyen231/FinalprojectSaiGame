using UnityEngine;
using UnityEngine.AI;


public class EnemyCtrl : PoolObj
{
    [Header("Enemy")]
    [SerializeField] protected Transform model;


    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected EnemyDamageReceiver damageReceiver;
    public EnemyDamageReceiver DamageReceiver => damageReceiver;

    int currentHp = 10;
    public float weight = 1f;
    //string enemyName = "";

    protected override void Awake()
    {
        base.Awake();
        this.RandomWeight();
    }

    protected virtual void OnEnable()
    {
        this.Reborn();
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
        this.damageReceiver = this.GetComponentInChildren<EnemyDamageReceiver>();
        Debug.LogWarning(transform.name + ":LoadDamageReceiver", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.model = transform.Find("Model");
        if (this.model != null) this.animator = this.model.GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
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

    protected virtual void Reborn()
    {
        this.model.localPosition = Vector3.zero;
        this.model.localRotation = Quaternion.identity;
    }
}