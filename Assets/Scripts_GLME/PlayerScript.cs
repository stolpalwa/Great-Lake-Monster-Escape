using UnityEngine;

public class PlayerScript : MonoBehaviour
{   
    public static Rigidbody playerRB; // Referens till spelarens (båtens) rigidbody-komponent (spelarens fysik)
    public float speed = 15.0f; // Hastigheten för spelarens (båtens) rörelse
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Hämta spelarens (båtens) rigidbody-komponent
    }

    void Update()
    {
        // Kollar tangentbords-inmatningen för HORISONTELL rörelse => (vänster pil/A eller höger pil/D)
        playerRB.linearVelocity = new Vector3 ((speed * Time.deltaTime) * Input.GetAxis("Horizontal"), 0, 0);

        if (playerRB.linearVelocity.x > 0) // Vänster rörelse
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
        }
        else if (playerRB.linearVelocity.x < 0) // Höger rörelse
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        }
        else // Ingen sido rörelse
        {
            transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
        }
    }
}
