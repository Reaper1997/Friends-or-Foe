using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson; //NEW

public class PlayerVitals : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth;
    public int healthFallRate;

    public Slider staminaSlider; 
    public int maxStamina; 
    private int staminaFallRate;
    public int staminaFallMult; 
    private int staminaRegainRate; 
    public int staminaRegainMult; 

    private CharacterController charController; 
    private FirstPersonController playerController; 

    void Start()
    {
        charController = GetComponent<CharacterController>(); 
        playerController = GetComponent<FirstPersonController>(); 

        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        staminaSlider.maxValue = maxStamina; 
        staminaSlider.value = maxStamina; 

        staminaFallRate = 1; 
        staminaRegainRate = 1;
    }

    void Update()
    {

        if (charController.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            staminaSlider.value -= Time.deltaTime / staminaFallRate * staminaFallMult;
        }

        else
        {
            staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMult;
        }

        if (staminaSlider.value >= maxStamina)
        {
            staminaSlider.value = maxStamina;
        }

        else if (staminaSlider.value <= 0)
        {
            staminaSlider.value = 0;
            playerController.m_RunSpeed = playerController.m_WalkSpeed;
        }

        else if (staminaSlider.value >= 0)
        {
            playerController.m_RunSpeed = playerController.m_RunSpeedNorm;
        }
    }

    void CharacterDeath()
    {
        
    }
}
