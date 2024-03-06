using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    [FormerlySerializedAs("fireRate")] public float attackRate;
    public float Health;
    public NavMeshAgent agent;
    public ParticleSystem bloodParticle;
    public Animator anim;
    [FormerlySerializedAs("fireTimer")] public float attackTimer;
    void Start()
    {
        anim.Play("Zombie Walk");
        agent.speed = moveSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckMovement();
    }

    void CheckMovement()
    {
        if(Vector3.Distance(transform.position,agent.destination) <=2f && agent.isStopped == false)
        {
            agent.isStopped = true;
            LookAtCamera();
            anim.Play("Attack");
           // transform.LookAt(Camera.main.transform);
        }
        if (agent.isStopped)
        {
            if (attackRate > attackTimer)
            {
                attackTimer += Time.deltaTime;
            }
            else
            {
                anim.Play("Attack");
                attackTimer = 0;
            }
        }
    }

    void LookAtCamera()
    {
        // Get the main camera's position
        Vector3 cameraPosition = Camera.main.transform.position;

        // Calculate the direction from the object to the camera
        Vector3 direction = cameraPosition - transform.position;

        // Zero out the y component so the object only rotates around the y-axis
        direction.y = 0;

        // Check if the direction vector is not zero
        if (direction != Vector3.zero)
        {
            // Create a quaternion (rotation) based on looking down the vector from the object to the camera
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Set the object's rotation to this new rotation
            transform.rotation = targetRotation;
        }
    }
  
    public void GetHit()
    {
        Health--;
        if (Health != 0)
        {
            bloodParticle.Play();
            anim.Play("Zombie Hit");
        }
        else
        {
            anim.Play("Zombie Die");
        }
    }

}
