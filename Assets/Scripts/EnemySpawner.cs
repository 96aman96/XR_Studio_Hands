using UnityEngine;
using NaughtyAttributes;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyPrefab;
    public Transform[] targets;
    public int SpawnRandom;
    void Start()
    {
        SpawnEnemy();
    }
    [NaughtyAttributes.Button]
    void SpawnEnemy()
    {
        SpawnRandom = Random.Range(0, 5);
        GameObject Enemy = GameObject.Instantiate(EnemyPrefab, targets[SpawnRandom]);
        Enemy.transform.localPosition = Vector3.zero;
        Enemy.transform.localRotation = Quaternion.identity;
        Enemy.GetComponent<NavMeshAgent>().destination = Camera.main.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
