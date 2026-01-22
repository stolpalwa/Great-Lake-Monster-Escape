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
        //StartCoroutine(StartAfterDelay());      // Anrop till korutin som styr en fördröjning av X antal sek innan båten börjar röra sig
        //StartCoroutine(PlaySoundEverySecond()); // Anrop till korutin som styr uppspelningen av startljudet
    }

    void Update()
    {
        // Tryck på mellanslagstangenten för att tillåta start av rörelse framåt (z-led)
        // (OBS: Detta gör att båten kan börja röra sig tidigare än efter 3 sekunder)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        // Om rörelsen är igång, flytta framåt (z-led)
        if (isMoving)
        {
            transform.Translate(Vector3.forward * currentSpeed); // * Time.deltaTime);

            // Vänster bana
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(-2, transform.position.y, transform.position.z);
            }
            // Mitten bana
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            }
            // Höger bana
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = new Vector3(2, transform.position.y, transform.position.z);
            }
        }
    }

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
