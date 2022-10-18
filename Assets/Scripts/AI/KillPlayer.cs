using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private Transform player;
    private float dist;
    public float killDist;

    public GameObject self;
    public GameObject deathScreenSelf;

    public bool isDead;

    public GameObject deathScreen;

    public FieldOfView fov;

    public Dead playerDead;

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
        if ((dist <= killDist) && (fov.canSeePlayer))
        {
            StartCoroutine(DeathTimer());
        }

        if (isDead)
        {
            deathScreenSelf.SetActive(true);
            self.SetActive(false);
            playerDead.amDead = true;


        }
        else
            deathScreen.SetActive(false);
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(3f);
        if ((dist <= killDist) && (fov.canSeePlayer))
        {
            Debug.Log("Dead!");
            isDead = true;
        }
        else
            yield return null;
    }

    
}
