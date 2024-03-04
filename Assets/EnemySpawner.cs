using UnityEngine;
using NaughtyAttributes;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyPrefab;
    public Transform[] targets;
    void Start()
    {
        
    }
    [NaughtyAttributes.Button]
    void SpawnEnemy()
    {
        GameObject Enemy = GameObject.Instantiate(EnemyPrefab, this.transform);
        Enemy.transform.localPosition = Vector3.zero;
        Enemy.transform.localRotation = Quaternion.identity;
        Enemy.GetComponent<NavMeshAgent>().destination = targets[Random.Range(0, targets.Length)].position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
