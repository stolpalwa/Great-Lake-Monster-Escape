using UnityEngine;
using System.Collections;
 
public class PlayerScript : MonoBehaviour
{
    public float fwdSpeed = 2f;     // Hastighet för båtens rörelse framåt
    public AudioSource startSound;  // Nedräkningsljud vid start av spelet

    private bool canMove = false;   // Flagga för att kontrollera när båten kan börja röra sig

    void Start()
    {
        //StartCoroutine(StartAfterDelay());      // Fördröjning innan båten börjar röra sig
        //StartCoroutine(PlaySoundEverySecond()); // Spela startljudet varje sekund
    }

    void Update()
    {
        // Tryck på mellanslagstangenten för att tillåta start av rörelse framåt (z-led)
        // (OBS: Detta gör att båten kan börja röra sig tidigare än efter 3 sekunder)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = true;
        }

        // Om rörelsen är igång, flytta framåt i z-led
        if (canMove)
        {
           transform.Translate(Vector3.forward * fwdSpeed * Time.deltaTime);
        }
    }

    IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        canMove = true;
    }

    IEnumerator PlaySoundEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (startSound != null)
            {
                startSound.Play();
            }
        }
    }
}
