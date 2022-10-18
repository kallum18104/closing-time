using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAI : MonoBehaviour
{
    private Transform player;
    private float dist;
    public float howClose;

    public FieldOfView fieldOfView;

    public WanderingAI Wander;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

    }

    private void FixedUpdate()
    {
        if (dist <= howClose)
        {
                Vector3 plyr = player.transform.position;
                Quaternion toRotation = Quaternion.FromToRotation(transform.forward, plyr);
                transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 2 * Time.time);
                Wander.wander = false;
                    


         //   fieldOfView.canSeePlayer = true;
        }
        else
        {
            Wander.wander = true;
        }
    }
}
