using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character : GameUnit
{
    public GameObject weaponHolder;
    public Weapons weapon;
    public Rigidbody rb;

    //Set target
    public List<Character> Targets = new List<Character>();
    [HideInInspector] public Character currentTarget;
    private Vector3 targetDirection;

    //Grow
    public Transform attackRangeScale;

    //Character data
    public float size;
    public float speed;
    public float attackRange => baseAttackRange * size;
    [HideInInspector] public float attackIntervalTimer;
    [HideInInspector] public float attackInterval;
    [SerializeField] private int point;
    private int pointToGrow;
    private float baseAttackRange;


    //Character action bool
    [HideInInspector] public bool isHit;
    [HideInInspector] public bool isAttack;

    //Animation
    public Animator animator;
    private string currentAnim;

    //StateMachine
    protected IState currentState;
    public IdleState IdleState = new();
    public RunState RunState = new();
    public PatrolState PatrolState = new();
    public AttackState AttackState = new();
    public DeadState DeadState = new();


    public virtual void OnEnable()
    {
        OnInit();
    }
    public override void OnInit()
    {
        size = 1f;
        speed = 10f;
        point = 0;
        pointToGrow = 5;
        baseAttackRange = 0.5f;
        attackInterval = 2f;
        attackIntervalTimer = attackInterval;
        //attackRangeCollider.radius = baseAttackRange;
        ChangeState(IdleState);
    }
    public override void OnDespawn() { }
    public virtual void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    //===========Moving==============
    public virtual void Moving() { }
    public virtual void Patrol() { }
    public virtual void ResetPatrol() { }
    public virtual void StopPatrol() { }
    public virtual void FindDirection() { }

    //===========Increase Size + Attack range==============
    public virtual void IncreasePoint()
    {
        point += 1;
        if (point >= pointToGrow)
        {
            Grow();
        }
    }
    public virtual void Grow()
    {
        size += 1;
        gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        //attackRangeCollider.radius = attackRange;
        pointToGrow += 5;
    }
    //===========Attack==============
    public virtual void CheckAroundCharacters() 
    {
        if (Targets.Count != 0)
        {
            currentTarget = Targets[0];
            isAttack = true;
            ChangeState(AttackState);
        }
    }
    public virtual void LookAtTarget()
    {
        if (currentTarget != null)
        {
            Vector3 lookDirection = currentTarget.transform.position - transform.position;
            lookDirection.y = 0f;
            lookDirection = lookDirection.normalized;
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
    public virtual void Attack()
    {
        targetDirection = currentTarget.transform.position - transform.position;
        weaponHolder.SetActive(false);
        weapon.Shoot(gameObject.GetComponent<Character>(),targetDirection);
    }
    public virtual void ResetAttack()
    {
        if (isAttack)
        {
            attackIntervalTimer -= Time.deltaTime;
            if (attackIntervalTimer <= 0)
            {
                ChangeState(IdleState);
                attackIntervalTimer = attackInterval;
            }
        }
    }
    public virtual void StopAttack()
    {
        weaponHolder.SetActive(true);
        isAttack = false;
        Targets.Remove(currentTarget);
        currentTarget = null;
    }
    public virtual void Hit()
    {
        isHit = true;
        if(isHit)
        {
            Die();
        }
    }
    //===========GameOver==============
    public virtual void Win() { }
    
    public virtual async void Die()
    {
        Targets.Clear();
        ChangeState(DeadState);
        await Task.Delay(TimeSpan.FromSeconds(1.5));
        DespawnWhenDie();
    }
    public virtual void DespawnWhenDie() { }

    //===========Animation==============
    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            animator.ResetTrigger(currentAnim);
            currentAnim = animName;
            animator.SetTrigger(currentAnim);
        }
    }
    //===========StateController==============
    public virtual void ChangeState(IState state)
    {
        if (currentState == state)
            return;
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

}
