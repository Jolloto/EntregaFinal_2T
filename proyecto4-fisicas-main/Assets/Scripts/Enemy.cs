using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2f;
    private Rigidbody enemyRigidbody;
    
    private GameObject player;

    private float lowerLimit = -3f;

    private SpawnManager spawnManager;
    private PlayerController playerController;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void Update()
    {
        if (!playerController.GetIsGameOver())
        {
            GoToPlayer();
        }

        if (transform.position.y < lowerLimit)
        {
            spawnManager.EnemyDestroyed();
            Destroy(gameObject);
        }
    }

    private void GoToPlayer()
    {
        // Direction = destino - origen
        // destino = posición del player
        // origen = posición del enemigo
        Vector3 direction = player.transform.position -
                            transform.position;
        direction = direction.normalized;
        enemyRigidbody.AddForce(direction * speed);
    }
}
