using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;

    NavMeshPath path;

    GameObject currentTarget = null;

    public float moveSpeed;

    public float attackRange;

    public float attack;

    public float fireRate;

    bool canAttack = true;

    float timer = 0f;

    public float turnSpeed;

    public float recoveryPeriod;

    public Image slowMeter;

    float slowTimer;

    bool isSlowed = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        agent.stoppingDistance = attackRange;
        agent.speed = moveSpeed;
    }

    void Update()
    {
        if (isSlowed)
        {
            slowTimer += Time.deltaTime;
            slowMeter.fillAmount = (recoveryPeriod - slowTimer) / recoveryPeriod;
            if (slowTimer >= recoveryPeriod)
            {
                slowTimer = 0;
                isSlowed = false;
                transform.Find("Canvas").gameObject.SetActive(false);
                agent.speed = moveSpeed;
            }
        }
        if (!canAttack)
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                timer = 0f;
                canAttack = true;
            }
        }
        if (currentTarget != null)
        {
            SetTarget(currentTarget);
            float distance = (currentTarget.transform.position - transform.position).magnitude;
            if (!agent.pathPending)
            {
                distance = agent.remainingDistance;
            }
            if (distance <= agent.stoppingDistance)
            {
                Vector3 direction = currentTarget.transform.position - transform.position;
                direction.Normalize();
                Vector3 newForward = Vector3.RotateTowards(transform.forward, direction, turnSpeed * Time.deltaTime, 0f);
                newForward.y = 0;
                transform.forward = newForward;
                if (canAttack)
                {
                    if (!currentTarget.GetComponent<RewindMotion>().GetState())
                    {
                        currentTarget.GetComponent<Health>().ChangeHealth(-attack);
                        GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Hurt by enemy causing damage");
                    }
                    canAttack = false;
                    timer = 0f;
                }
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        agent.SetDestination(target.transform.position);
        currentTarget = target;
    }

    public bool CheckPath(GameObject target)
    {
        bool status = agent.CalculatePath(target.transform.position, path);
        Debug.Log(status);
        return status;
    }

    public void Slow()
    {
        isSlowed = true;
        agent.speed = moveSpeed / 2;
        transform.Find("Canvas").gameObject.SetActive(true);
        slowTimer = 0;
    }
}
