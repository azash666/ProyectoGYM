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

    // Audio e imagen de muerte del player
    public AudioSource deathSound;
    public RawImage imagenMuerte;
    
    // Cuando el player muere
    bool isDead = false;

    //Inmunidad
    public bool isInmune = false;
    float inmuneTimer = 0.0f;
    public RawImage imagenInmunidad;

    //Vida
    public bool isHeal = false;
    public RawImage imagenVida;
    float healTimer = 0.0f;

    

    void Start()
    {
        // Setting up the references.

        // Set the initial health of the player.
        currentHealth = startingHealth;
        //imagenInmunidad = GameObject.Find("ImagenInmunidad").GetComponent<RawImage>();
        imagenInmunidad.enabled = false;
        imagenVida.enabled = false;
        imagenMuerte.enabled = false;
    }

    void Update()
    {
      
        if (isInmune)
        {
            inmuneTimer += Time.deltaTime;
            imagenInmunidad.enabled = true;

            if (inmuneTimer >= 5.0f && inmuneTimer <= 6.0f)
            {
                isInmune = false;
                inmuneTimer = 0.0f;
                imagenInmunidad.enabled = false;
            }
        }

        if (isHeal)
        {

            if (currentHealth <= 7)
            {
                currentHealth += 3;
            }

            else
            {
                currentHealth = 10;
            }

            healthSlider.value = currentHealth;

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

            healTimer += Time.deltaTime;
            imagenVida.enabled = true;

            if (healTimer >= 2.0f && healTimer <= 3.0f)
            {
                healTimer = 0.0f;
                imagenVida.enabled = false;
                isHeal = false;
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
        imagenMuerte.enabled = true;

        // Reproducimos el sonido de la muerte
        deathSound.Play();

        //GameController.numVivos = 10;
        //GameController.numZombies = 10;
    }
}
