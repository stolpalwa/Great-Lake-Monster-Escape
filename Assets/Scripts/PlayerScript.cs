using Codice.CM.Common;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{   
    public float moveSpeed = 10.0f; // Hastigheten för spelarens (båtens) rörelse
    public static Rigidbody playerRB; // Referens till spelarens (båtens) rigidbody-komponent (spelarens fysik)

    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Hämta spelarens (båtens) rigidbody-komponent
    }

    void Update()
    {
        //Kollar tangentinmatningen inputGetAxis för horisontell rörelse (vänster och höger)
        //playerRB.linearVelocity = new Vector3 ((moveSpeed * Time.deltaTime) * Input.GetAxis("Horizontal"), 0, 0);

        //if (playerRB.linearVelocity.x < 0) // Höger rörelse
        //{
        //    Debug.Log("Moving Right");
        //}
        //else if (playerRB.linearVelocity.x > 0) // Vänster rörelse
        //{
        //    Debug.Log("Moving Left");
        //}

        // Fungerar inte som tänkt ännu...
        // Kollar tangentbords-inmatningen för horisontell rörelse (vänster pil/A eller höger pil/D)
        playerRB.linearVelocity = new Vector3(moveSpeed * Input.GetAxis("Horizontal"), 0, 0);

        if (playerRB.position.x < 0) // Vänster bana
        {
            transform.position = new Vector3(-2, 0, 0); // * Time.deltaTime;
        }


        if (playerRB.linearVelocity.x == 0) // Mitten 
        {
            transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
        }


        if (playerRB.position.x > 0) // Höger bana
        {
            transform.position = new Vector3(2, 0, 0); // * Time.deltaTime;
        }
    }
}
}
