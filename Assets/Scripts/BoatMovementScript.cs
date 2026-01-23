using UnityEngine;

public class BoatMovementScript : MonoBehaviour
{
    public bool isMoving = false;               // Kontrollerar om båten rör sig framåt eller inte
    public bool isBoosting = false;             // Kontrollerar om båten plockat upp en livboj för hastighetsökning
    public float speed = 2f;                    // Normal astighet för förflyttning
    public float boostSpeed = 5f;               // Hastighet vid boost
    private float currentSpeed;                 // Nuvarande hastighet
    public float boostDuration = 2f;            // Hur länge boosten varar

    private float[] lanes = { -2f, 0f, 2f };    // Array för att lagra x-positioner för de tre banorna
    private int currentLaneIndex = 1;           // Index för nuvarande bana (0 = vänster, 1 = mitten, 2 = höger)

    
    public int health = 3;                      // Header("Liv & Status")

    void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        // Flytt av båten framledes (z-led) när spelaren trycker ned space.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        if (isMoving)
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime); // Testar att byta ut speed mot currentSpeed för boost

            // Anropar metoderna nedan //
            HandleInput();
            MoveToLane();
        }
    }

    private void HandleInput()
    {
        // Metod för att hantera tangentbordsinmatning för att byta bana.
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLaneIndex > 0) // Flytta vänster 
        {
            currentLaneIndex--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLaneIndex < lanes.Length - 1) // Flytta höger
        {
            currentLaneIndex++;
        }
    }

    // Metod för att flytta båten mot den valda banans X-position.
    private void MoveToLane()
    {
        Vector3 targetPosition = new Vector3(lanes[currentLaneIndex], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed); // För mjukare sidorörelse lägg till * Time.deltaTime);
    }

    public void ActivateSpeedBoost()
    {
        // Metod för att aktivera hastighetsökning när livbojen plockas upp. //
        speed *= 1.5f; // Öka hastigheten med 50%
        Invoke("DeactivateSpeedBoost", 5f); // Återställ hastigheten efter 5 sekunder
    }

    //public void ActivateSpeedBoost()
    //{
    //    if (!isBoosting)
    //        StartCoroutine(SpeedBoost());
    //}

    //private System.Collections.IEnumerator SpeedBoost()
    //{
    //    isBoosting = true;
    //    currentSpeed = boostSpeed;
    //    yield return new WaitForSeconds(boostDuration);
    //    currentSpeed = speed;
    //    isBoosting = false;
    //}
}
