using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerManager : MonoBehaviour
{
    [SerializeField] private float addedForce = 380.0f;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float destroyAfter = 10.0f;  
    
    public void Shoot()
    {
        GameObject bullet = Instantiate(ballPrefab, transform.position, Quaternion. identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * addedForce) ;
        Destroy (bullet, destroyAfter);
    }
    
}

