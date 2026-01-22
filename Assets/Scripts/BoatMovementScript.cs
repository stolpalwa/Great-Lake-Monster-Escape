using UnityEngine;

public class BoatMovementScript : MonoBehaviour
{
    [Header("Rörelseinställningar")]
    public bool isMoving = false;
    public float speed = 5f;        // Bas-hastighet
    public float currentSpeed;      // Den hastighet båten faktiskt rör sig med just nu

    [Header("Boost-inställningar")]
    public bool isBoosting = false;
    public float boostMultiplier = 1.5f;
    public float boostDuration = 2f;

    [Header("Liv & Status")]
    public int health = 3;          // Spelarens liv (används av ObstacleScript)

    private float[] lanes = { -2f, 0f, 2f };
    private int currentLaneIndex = 1;

    void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        // Starta spelet med mellanslag
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        if (isMoving)
        {
            // Flytta framåt baserat på currentSpeed
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

            HandleInput();
            MoveToLane();
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLaneIndex > 0)
        {
            currentLaneIndex--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLaneIndex < lanes.Length - 1)
        {
            currentLaneIndex++;
        }
    }

    private void MoveToLane()
    {
        // Vi räknar ut målpositionen (behåller nuvarande Y och Z)
        Vector3 targetPosition = new Vector3(lanes[currentLaneIndex], transform.position.y, transform.position.z);

        // Flyttar båten i sidled. Använder speed * 2 för att sidoförflyttningen ska kännas rapp.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * 5f * Time.deltaTime);
    }

    public void ActivateSpeedBoost()
    {
        // Vi kollar så att vi inte redan boostar (för att undvika att starta flera samtidigt)
        if (!isBoosting)
        {
            StartCoroutine(SpeedBoostRoutine());
        }
    }

    private System.Collections.IEnumerator SpeedBoostRoutine()
    {
        isBoosting = true; // Här aktiveras din bool!
        currentSpeed = speed * boostMultiplier;

        Debug.Log("Boost startad: isBoosting = " + isBoosting);

        // Vänta i x sekunder
        yield return new WaitForSeconds(boostDuration);

        currentSpeed = speed; // Återställ hastighet
        isBoosting = false;   // Här stängs den av!

        Debug.Log("Boost avslutad: isBoosting = " + isBoosting);
    }
}