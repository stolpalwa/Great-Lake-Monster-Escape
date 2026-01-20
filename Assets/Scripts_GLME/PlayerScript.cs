using UnityEngine;

public class PlayerScript : MonoBehaviour
{   
    public static Rigidbody playerRB; // Referens till spelarens (båtens) rigidbody-komponent (spelarens fysik)
    public float speed = 10.0f; // Hastigheten för spelarens (båtens) rörelse
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Hämta spelarens (båtens) rigidbody-komponent
    }

    void Update()
    {
        //Kollar tangentinmatningen inputGetAxis för horisontell rörelse (vänster och höger)
        playerRB.linearVelocity = new Vector3 ((speed * Time.deltaTime) * Input.GetAxis("Horizontal"), 0, 0);

        if (playerRB.linearVelocity.x < 0) // Vänster rörelse
        {
            // Moves the object forward at two units per second.
            transform.position = new Vector3(-1, 0, 0) * Time.deltaTime;
            Debug.Log("Moving Left");
        }
        else if (playerRB.linearVelocity.x > 0) // Höger rörelse
        {
            transform.position = new Vector3(1, 0, 0) * Time.deltaTime;
            Debug.Log("Moving Right");
        }
    }
}
