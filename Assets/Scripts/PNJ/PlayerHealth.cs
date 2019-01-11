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

    // Audio cuando muere el player
    public AudioSource deathSound;
    public GameObject deathImage;
    
    // Cuando el player muere
    public Animator animDead;
    bool isDead = false;

    public bool isInmune = false;
    float inmuneTimer = 0.0f;

    public bool isHeal = false;

    void Start()
    {
        // Setting up the references.

        // Set the initial health of the player.
        currentHealth = startingHealth;
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

        if (isHeal)
        {
            currentHealth += 3;
            isHeal = false;

            // Cambiar la vida de color
            if (currentHealth < 7 && currentHealth >= 4)
            {
                Fill.color = Color.yellow;
            }

            else if (currentHealth < 4)
            {
                Fill.color = Color.red;
            }

            else
            {
                Fill.color = Color.green;
            }
        }

    }

    // Cuando dañan al player
    public void TakeDamage(int amount)
    {
        if (! isInmune)
        {
            // Reducimos la barra de vida del player
            currentHealth -= amount;

            // Ponemos la barra de vida con la vida actual
            healthSlider.value = currentHealth;

            // Reproducimos el sonido del daño recibido
            damageSound.Play();

            // Cambiar la vida de color
            if (currentHealth < 7 && currentHealth >= 4)
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
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        deathImage.SetActive(true);

        // Reproducimos el sonido de la muerte
        deathSound.Play();
    }
}
