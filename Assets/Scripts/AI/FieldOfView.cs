using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;


public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public WanderingAI self;

    public NavMeshAgent agent;


    public Transform playerLoc;

    public Animator selfAnim;

//    public AudioSource detect;

    public float lerpTime;

    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    [Range(0,10)]
    public float threshold = 0.1f;



    float max = 1f;
    float min = 0f;

    float loudness;




    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        
        StartCoroutine(FOVRoutine());

    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void Update()
    {
        loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if ((Vector3.Angle(transform.forward, directionToTarget) < angle / 2))
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if ((!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)))
                {
                    Debug.Log("Chasing!");

                    StartCoroutine(ChasePlayer());
                    selfAnim.SetBool("Chase", true);
                }

                else
                {
                    canSeePlayer = false;
                    self.wander = true;
                    radius = 7;
                    angle = 120;
                    agent.speed = 5f;

                    Transform lastPosition = playerRef.transform;
                    selfAnim.SetBool("Chase", false);

                    agent.SetDestination(lastPosition.transform.position);

                    Debug.Log("Checking last position");
                }
            } 
            else
            {
                canSeePlayer = false;
                self.wander = false;
                radius = 7;
                angle = 120;
                agent.speed = 5f;

                Transform lastPosition = playerRef.transform;

                agent.SetDestination(lastPosition.transform.position);

                Debug.Log("Checking last position");
            }
        }
        else if (loudness > threshold)
        {
            Debug.Log("Chasing!");

            StartCoroutine(ChasePlayer());
            selfAnim.SetBool("Chase", true);
        }
        else if (canSeePlayer) {
            canSeePlayer = false;
            self.wander = true;
            radius = 7;
            angle = 120;
            agent.speed = 5f;

        }

        IEnumerator ChasePlayer()
        {
                   canSeePlayer = true;
                   self.wander = false;
                   agent.SetDestination(playerRef.transform.position);
                   radius = 300;
                   angle = 360;
                   agent.speed = 10f;
                   playerLoc = playerRef.transform;
         yield return new WaitForSeconds(30);
           
        }
    }

   
}
