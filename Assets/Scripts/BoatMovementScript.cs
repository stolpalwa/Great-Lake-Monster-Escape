using UnityEngine;
 
public class BoatMovementScript : MonoBehaviour
{
    public bool isMoving = false;   // Flagga för att kontrollera när båten kan börja röra sig
    public bool isBoosting = false; // Flagga för att kontrollera om båten har en hastighetsboost aktiv
    public float speed = 2f;     // Hastighet för båtens rörelse framåt
    public float currentSpeed;
    public float boostDuration = 2f;    // Hur länge boosten varar

    private float[] lanes = { -2f, 0f, 2f }; // Array för att lagra x-positioner för de tre banorna
    private int currentLaneIndex = 1;       // Index för nuvarande bana (0 = vänster, 1 = mitten, 2 = höger)
    // public AudioSource startSound;  // Nedräkningsljud vid start av spelet

 
    void Start()
    {
        currentSpeed = speed; // Sätt den aktuella hastigheten till standardhastigheten vid start
        //StartCoroutine(PlaySoundEverySecond()); // Anrop till korutin som styr uppspelningen av startljudet
    }

    void Update()
    {
        // Tryck på mellanslagstangenten för att tillåta start av rörelse framåt (z-led)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        // Om rörelsen är igång, flytta framåt (z-led)
        if (isMoving)
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

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


    // Kommenterade ut nedanstående korutiner för att undvika ljudproblem under testning

    //IEnumerator StartAfterDelay()
    //{
    //    yield return new WaitForSeconds(3f);
    //    isMoving = true;
    //}

    //IEnumerator PlaySoundEverySecond()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(1f);

    //        if (startSound != null)
    //        {
    //            startSound.Play();
    //        }
    //    }
    //}

}
