using UnityEngine;
using System.Collections;
 
public class PlayerScript : MonoBehaviour
{
    public float fwdSpeed = 2f;     // Hastighet för båtens rörelse framåt
    // public AudioSource startSound;  // Nedräkningsljud vid start av spelet

    private bool canMove = false;   // Flagga för att kontrollera när båten kan börja röra sig

    void Start()
    {
        //StartCoroutine(StartAfterDelay());      // Anrop till korutin som styr en fördröjning av X antal sek innan båten börjar röra sig
        //StartCoroutine(PlaySoundEverySecond()); // Anrop till korutin som styr uppspelningen av startljudet
    }

    void Update()
    {
        // Tryck på mellanslagstangenten för att tillåta start av rörelse framåt (z-led)
        // (OBS: Detta gör att båten kan börja röra sig tidigare än efter 3 sekunder)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = true;
        }

        // Om rörelsen är igång, flytta framåt (z-led)
        if (canMove)
        {
            transform.Translate(Vector3.forward * fwdSpeed * Time.deltaTime);

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
    //    canMove = true;
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
