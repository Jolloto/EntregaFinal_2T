using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;

    private float spawnLimit = 8f;

    private int enemiesInScene;
    private int enemiesPerWave = 1;

    private PlayerController playerController;

    private bool powerupInScene;
    
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        powerupInScene = false;
        enemiesPerWave = 1;
        SpawnEnemyWave(enemiesPerWave);
    }

    private void Update()
    {
        //enemiesInScene = FindObjectsOfType<Enemy>().Length;
        
        if (enemiesInScene <= 0)
        {
            enemiesPerWave++;
            if (!playerController.GetIsGameOver())
            {
                SpawnEnemyWave(enemiesPerWave);
            }  
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), Quaternion.identity);
            enemiesInScene++;
        }

        if (!powerupInScene && enemiesToSpawn > 1)
        {
            Instantiate(powerupPrefab,
                GenerateRandomPosition(), 
                Quaternion.identity);

            powerupInScene = true;
        }
    }

    public void PowerupFinished()
    {
        powerupInScene = false;
    }

    public void EnemyDestroyed()
    {
        enemiesInScene--;
    }

    private Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-spawnLimit, spawnLimit);
        float z = Random.Range(-spawnLimit, spawnLimit);

        return new Vector3(x, 0, z);
    }
}
