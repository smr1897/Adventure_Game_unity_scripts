using Retro.ThirdPersonCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonAttack : MonoBehaviour
{
    [Header("Dragon health and damage")]
    private float dragonHealth = 125f;
    private float presentHealth;
    public float giveDamage;
    public GameObject Dragon;

    [Header("Dragon Things")]
    public NavMeshAgent dragonAgent;
    public Transform LookPoint;
    public Camera fireRayCastArea;
    public Transform playerBody;
    public LayerMask playerLayer;

    [Header("Dragon Guarding")]
    public GameObject[] walkPoints;
    int currentDragonPosition = 0;
    public float DragonSpeed;
    float walkingPointRadius;

    [Header("Sounds and UI")]

    [Header("Dragon firing")]

    public float timeBetweenFire;

    bool previouslyFire;

    [Header("Dragon Animation and spark Effect")]

    public Animator animator;

    [Header("Dragon mood/Situation")]

    public float visionRadius;
    public float firingRadius;
    public bool PlayerInVisionRadius;
    public bool PlayerInFiringRadius;

    public SkyChanger skyChanger;

    //public bool IsInVisionRadius;

    private void Awake()
    {
        presentHealth = dragonHealth;
        playerBody = GameObject.Find("Player-Default").transform;
        dragonAgent = GetComponent<NavMeshAgent>();
        Dragon = GetComponent<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerInVisionRadius = Physics.CheckSphere(transform.position, visionRadius, playerLayer);
        PlayerInFiringRadius = Physics.CheckSphere(transform.position, firingRadius, playerLayer);

        if(!PlayerInVisionRadius && !PlayerInFiringRadius) 
        {
            //Guard();
        }

        if(PlayerInVisionRadius && !PlayerInFiringRadius)
        {
            PursuePlayer();
            //setIsInVisionRadius();
            //if (!IsInVisionRadius)
            //{
                //IsInVisionRadius = true;
                //skyChanger.SetNight();
            //}

            
            
        }

        if(PlayerInVisionRadius && PlayerInFiringRadius)
        {
            FireAtPlayer();
        }
    }

    private void Guard()
    {
        /*if (Vector3.Distance(walkPoints[currentDragonPosition].transform.position , transform.position) < walkingPointRadius)
        {
            currentDragonPosition = Random.Range(0, walkPoints.Length);
            if(currentDragonPosition >= walkPoints.Length) 
            {
                currentDragonPosition = 0;
            }

        }

        transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentDragonPosition].transform.position, Time.deltaTime * DragonSpeed);

        transform.LookAt(walkPoints[currentDragonPosition].transform.position);*/
        animator.SetBool("Idle", true);
        animator.SetBool("StayIdle", false);
        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);
        animator.SetBool("MouthAttack", false);
        animator.SetBool("Die", false);
    }

    private void PursuePlayer()
    {
        //skyChanger.InVisionRadius = true;

        if(dragonAgent.SetDestination(playerBody.position))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("StayIdle", false);
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
            animator.SetBool("MouthAttack", false);
            animator.SetBool("Die", false);

            visionRadius = 60f;
            firingRadius = 15f;

        }

        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("StayIdle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
            animator.SetBool("MouthAttack", false);
            animator.SetBool("Die", true);
        }
    }

    private void FireAtPlayer()
    {
        dragonAgent.SetDestination(transform.position);

        transform.LookAt(LookPoint);

        if(!previouslyFire)
        {
            RaycastHit hit;

            if(Physics.Raycast(fireRayCastArea.transform.position , fireRayCastArea.transform.forward , out hit , firingRadius))
            {
                Debug.Log("Firing" + hit.transform.name);

                Movement playerBody = hit.transform.GetComponent<Movement>();

                if(playerBody != null) 
                {
                    playerBody.playerHitDamage(5f);
                }

                animator.SetBool("Idle", false);
                animator.SetBool("Run", false);
                animator.SetBool("StayIdle", false);
                animator.SetBool("Attack", true);
                animator.SetBool("MouthAttack", false);
                animator.SetBool("Die", false);
            }

            previouslyFire = true;
            Invoke(nameof(activeFiring), timeBetweenFire);
        }

    }

    private void activeFiring()
    {
        previouslyFire = false;

        
    }

    private void DragonDamage(float takeDamage)
    {
        if (presentHealth <= 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
            animator.SetBool("MouthAttach", false);
            animator.SetBool("Die", true);

            //skyChanger.DragonKilled();
            DragonDeath();

        }
    }

    private void DragonDeath()
    {
        dragonAgent.SetDestination(transform.position);
        DragonSpeed = 0f;
        firingRadius = 0f;
        visionRadius = 0f;
        PlayerInVisionRadius = false;
        PlayerInFiringRadius = false;
    }

    /*private void setIsInVisionRadius()
    {
        if(!IsInVisionRadius)
        {
            IsInVisionRadius = true;
            skyChanger.SetNight();
        }
    }*/
}
