using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    public GameObject BloodParticle;

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            GameObject splat = GameObject.Instantiate(BloodParticle);
            splat.transform.position = other.contacts[0].point;
            splat.transform.localScale = new Vector3(.7f, .7f, .7f);
            splat.transform.rotation = Random.rotation;
            Destroy(this.gameObject);
            other.transform.GetComponent<EnemyController>().GetHit();
        }
    }
    
}
