using UnityEngine;
using System.Collections;
 
public class PlayerScript : MonoBehaviour
{
    public float fwdSpeed = 2f;     // Hastighet för båtens rörelse framåt
    public AudioSource startSound;   // Nedräkningsljud vid start av spelet

    private bool canMove = false;

    void Start()
    {
        StartCoroutine(StartAfterDelay());      // Fördröjning innan båten börjar röra sig
        StartCoroutine(PlaySoundEverySecond()); // Spela startljudet varje sekund
    }

    void Update()
    {
        //if (canMove)
        //{
        //    transform.Translate(Vector3.forward * fwdSpeed * Time.deltaTime);
        //}

        // TEST!!! Aktivera rörelse framåt när spelaren trycker ner spacetangenten
        if (Input.GetKeyDown(KeyCode.Space))
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
