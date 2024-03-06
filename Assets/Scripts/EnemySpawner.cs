using UnityEngine;
using NaughtyAttributes;
using UnityEditor.Experimental;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyPrefab;
    public Transform[] targets;
    public int SpawnRandom;
    private float elapsed, timer, counter;
    void Start()
    {
 //       SpawnEnemy();
    }
    [NaughtyAttributes.Button]
    void SpawnEnemy()
    {
        SpawnRandom = Random.Range(0, 5);
        counter++;
        timer = Random.Range(2, 4);
        GameObject Enemy = GameObject.Instantiate(EnemyPrefab, targets[SpawnRandom]);
        Enemy.transform.localPosition = Vector3.zero;
        Enemy.transform.localRotation = Quaternion.identity;
        Enemy.GetComponent<NavMeshAgent>().destination = Camera.main.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (elapsed > timer && counter <20)
        {
            SpawnEnemy();
            elapsed = 0;
        }
        else
        {
            elapsed += Time.deltaTime;
        }
    }
}
