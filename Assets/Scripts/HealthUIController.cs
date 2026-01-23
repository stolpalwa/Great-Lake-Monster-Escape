using UnityEngine;

public class HealthUIController : MonoBehaviour
{
    [Header("References")]
    public BoatMovementScript boatMovementScript;

    [Header("UI Slots")]
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject endScreen;

    void Update()
    {
        if (boatMovementScript == null) return;

        UpdateHealthUI(boatMovementScript.health);
    }

    void UpdateHealthUI(int currentHealth)
    {
        // Handle Health Icons
        // We use comparisons so that if health is 3, all are true. 
        // If health is 2, only 1 and 2 are true, etc.
        health1.SetActive(currentHealth >= 1);
        health2.SetActive(currentHealth >= 2);
        health3.SetActive(currentHealth >= 3);

        // Handle End Screen
        if (currentHealth <= 0)
        {
            endScreen.SetActive(true);
        }
        else
        {
            endScreen.SetActive(false);
        }
    }
}
