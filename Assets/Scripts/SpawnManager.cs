using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] enemies;
    [SerializeField] private Transform player; 
    private float spawnY = 0.1f;
    private float spawnInterval = 5f;
    private float spawnRangeX = 20f;  
    private float spawnRangeZ = 20f; 

    void Start()
    {
        InvokeRepeating("SpawnZombies", 0f, spawnInterval);
    }

    void SpawnZombies()
    {
        Vector3 playerPosition = player.position;

        Vector3 spawnPosition = new Vector3(
            Random.Range(playerPosition.x - spawnRangeX, playerPosition.x + spawnRangeX),
            spawnY,
            Random.Range(playerPosition.z - spawnRangeZ, playerPosition.z + spawnRangeZ)
        );

        // Debug log to see the spawn position
        Debug.Log("Attempting to spawn at: " + spawnPosition);

        // Check for overlap with other colliders
        //if (!Physics.CheckSphere(spawnPosition, 1f)) // You can adjust the radius if needed
        
            int index = Random.Range(0, enemies.Length);
            Instantiate(enemies[index], spawnPosition, enemies[index].transform.rotation);
            Debug.Log("Zombie spawned!");
        
    }
}
