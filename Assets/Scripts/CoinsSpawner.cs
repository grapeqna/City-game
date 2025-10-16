using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] public GameObject coin;
    [SerializeField] private Transform player; 
    private float spawnY = 1.5f;
    private float spawnInterval = 2f;
    private float spawnRangeX = 20f;  
    private float spawnRangeZ = 20f;  

    void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    void SpawnCoin()
    {
        Vector3 playerPosition = player.position;

        Vector3 spawnPosition = new Vector3(
            Random.Range(playerPosition.x - spawnRangeX, playerPosition.x + spawnRangeX),
            spawnY,
            Random.Range(playerPosition.z - spawnRangeZ, playerPosition.z + spawnRangeZ)
        );

        // Check for overlap with other colliders
        if (!Physics.CheckSphere(spawnPosition, 1f)) // You can adjust the radius if needed
        {
            Instantiate(coin, spawnPosition, coin.transform.rotation);
        }
    }
}
