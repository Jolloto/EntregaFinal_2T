using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float speed = 10f;
    private float forwardInput;

    private SpawnManager spawn;
    [SerializeField] private GameObject focalPointGameObject;

    public bool hasPowerup;
    private float powerupForce = 30f;

    [SerializeField] private GameObject[] powerupIndicators;

    private int lives;
    private float lowerLimit = -3f;
    private bool isGameOver;
    private Vector3 initialPosition;

    private UI_MANAGER uiManager;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        
        hasPowerup = false;
        initialPosition = Vector3.zero;
        lives = 3;
        isGameOver = false;
    }

    private void Start()
    {
        uiManager = FindObjectOfType<UI_MANAGER>();
        uiManager.HideGameOverPanel();
        uiManager.ShowMenuPanel();
        uiManager.HidePausaPanel();
        spawn = FindObjectOfType<SpawnManager>();
        HideAllPowerupIndicators();
    }

    public void StartGame()
    {
        
        uiManager.HidePausaPanel();

    }

        private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        Movement();

        if (transform.position.y < lowerLimit)
        {
            lives--;
            if (lives <= 0)
            {
                //GAME OVER
                isGameOver = true;
            }
            else
            {
                // Puedo seguir jugando
                transform.position = initialPosition;
                playerRigidbody.velocity = Vector3.zero;
                StartCoroutine(InvulnerabilityCountdown());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            StartCoroutine(PowerupCountdown());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // El enemigo sufre un empujón alejándolo del player
            Rigidbody enemyRigidbody = other.gameObject.
                GetComponent<Rigidbody>();
            
            Vector3 direction = (other.transform.position -
                                 transform.position).normalized;
            
            enemyRigidbody.AddForce(direction * powerupForce,
                ForceMode.Impulse);
        }
    }

    private void Movement()
    {
        forwardInput = Input.GetAxis("Vertical");
        
        playerRigidbody.AddForce(focalPointGameObject.transform.forward * 
                                 speed * forwardInput);
        
        // SI QUEREMOS QUE EL PLAYER FRENE CUANDO NO PULSAMOS VERTICAL INPUT
        // // forwardInput > -0.01f && forwardInput < 0.01f
        // if (Mathf.Abs(forwardInput) < 0.01f)
        // {
        //     playerRigidbody.velocity = Vector3.zero;
        // }
        // else
        // {
        //     playerRigidbody.AddForce(focalPointGameObject.transform.forward * 
        //                              speed * forwardInput);
        // }
    }

    private IEnumerator PowerupCountdown()
    {
        for (int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(false);
        }
    
        hasPowerup = false;
        spawn.PowerupFinished();
    }

    private IEnumerator InvulnerabilityCountdown()
    {
        playerRigidbody.constraints = RigidbodyConstraints.FreezePosition |
            RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(0.5f);
        playerRigidbody.constraints = RigidbodyConstraints.None;
    }

    private void HideAllPowerupIndicators()
    {
        foreach (GameObject indicator in powerupIndicators)
        {
            indicator.SetActive(false);
        }
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }
}