using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{   
    // Vida del player, vida actual del player, referencia a la barra de vida
    public int startingHealth = 10;                           
    public int currentHealth;                                 
    public Slider healthSlider;
    public Image Fill;

    // Audio cuando dañan al player                                 
    public AudioSource damageSound;

    // Imagen y audio cuando muere el player
    public Image deathImage;
    public AudioSource deathSound;
    
    // Cuando el player muere
    bool isDead;

    private SimpleCharacterControl playerMovement;

    public bool isInmune = false;
    float inmuneTimer = 0.0f;

    void Awake()
    {
        // Setting up the references.

        // Set the initial health of the player.
        currentHealth = startingHealth;

        // Obtenemos los scripts
        playerMovement = GameObject.Find("SimpleCharacterControl").GetComponent<SimpleCharacterControl>();
    }

    void Update()
    {
        
        if (isInmune)
        {
            inmuneTimer += Time.deltaTime;

            if (inmuneTimer == 5.0f)
            {
                isInmune = false;
                inmuneTimer = 0.0f;
            }
        }

    }


    // Cuando dañan al player
    public void TakeDamage(int amount)
    {
        // Reducimos la barra de vida del player
        currentHealth -= amount;

        // Ponemos la barra de vida con la vida actual
        healthSlider.value = currentHealth;

        // Reproducimos el sonido del daño recibido
        damageSound.Play();

        // Cambiar la vida de color
        if (currentHealth < 7)
        {
            Fill.color = Color.yellow;
        }

        else if (currentHealth < 4)
        {
            Fill.color = Color.red;
        }

        // Si el player esta muerto
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Reproducimos el sonido de la muerte
        deathSound.Play();

        // Deshabilitamos los scripts
        playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }
}
