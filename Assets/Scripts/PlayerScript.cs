

//    void Update()
//    {
//        //Kollar tangentinmatningen inputGetAxis för horisontell rörelse (vänster och höger)
//        //playerRB.linearVelocity = new Vector3 ((moveSpeed * Time.deltaTime) * Input.GetAxis("Horizontal"), 0, 0);

//        //if (playerRB.linearVelocity.x < 0) // Höger rörelse
//        //{
//        //    Debug.Log("Moving Right");
//        //}
//        //else if (playerRB.linearVelocity.x > 0) // Vänster rörelse
//        //{
//        //    Debug.Log("Moving Left");
//        //}

//        // Fungerar inte som tänkt ännu...
//        // Kollar tangentbords-inmatningen för horisontell rörelse (vänster pil/A eller höger pil/D)
//        playerRB.linearVelocity = new Vector3(moveSpeed * Input.GetAxis("Horizontal"), 0, 0);

//        if (playerRB.position.x < 0) // Vänster bana
//        {
//            transform.position = new Vector3(-2, 0, 0); // * Time.deltaTime;
//        }


//        if (playerRB.linearVelocity.x == 0) // Mitten 
//        {
//            transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
//        }


//        if (playerRB.position.x > 0) // Höger bana
//        {
//            transform.position = 0new Vector3(2, 0, 0); // * Time.deltaTime;
//        }
//    }

using UnityEngine;
using System.Collections;
 
public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 2f;     // Hastighet för spelarens (båtens) framåtrörelse
    public AudioSource tickSound;    // Sound that plays every second

    private bool canMove = false;

    void Start()
    {
        StartCoroutine(StartAfterDelay());
        StartCoroutine(PlaySoundEverySecond());
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
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

            if (tickSound != null)
            {
                tickSound.Play();
            }
        }
    }
}
