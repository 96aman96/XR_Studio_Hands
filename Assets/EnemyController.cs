using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed,fireRate,Health,deathRandom;
    public NavMeshAgent agent;
    public Transform targetPos,FirePos;
    public ParticleSystem bloodParticle;
    public Animator anim;
    private float fireTimer;
    public GameObject BulletPrefab;
    void Start()
    {
        anim.Play("");
    }

    // Update is called once per frame
    void CheckMovement()
    {
        if (agent.isStopped)
        {
            transform.LookAt(Camera.main.transform);
            if (fireTimer < fireRate)
            {
                fireTimer += Time.deltaTime;
            }
            else
            {
                fireTimer = 0;
                FireBullet();
            }
        }
    }


    void FireBullet()
    {
        GameObject bullet = GameObject.Instantiate(BulletPrefab, this.transform);
    }
    public void playHitAnim()
    {
        Health--;
        int rand = Random.Range(1, 3);
        if (Health != 0)
        {
            bloodParticle.Play();
            anim.Play("Hit" + rand);
        }
        else
        {
            anim.Play("Death"+rand);
        }
    }

}
