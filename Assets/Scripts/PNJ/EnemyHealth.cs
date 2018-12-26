using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{   
    // Vida inicial, vida actual
    public int startingHealth = 10;           
    public int currentHealth;

    // Sonido de muerte, sonido de daño
    public AudioSource deathSound;
    public AudioSource damageSound;


    Animator anim;                              // Reference to the animator.
    AudioSource enemyAudio;                     // Reference to the audio source.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.

    ParticleSystem hitParticles;


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }


    // Cuando dañan al enemigo
    public void TakeDamage(int amount)
    {
        // Reproducimos el sonido del daño
        damageSound.Play();

        // Reducimos su vida
        currentHealth -= amount;

        // Si esta muerto
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
        anim.SetTrigger("Dead");

        // Reproducimos el sonido de muerte
        deathSound.Play();
    }


    public void StartSinking()
    {
        // Find and disable the Nav Mesh Agent.
        GetComponent<NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // After 2 seconds destory the enemy.
        Destroy(gameObject, 2f);
    }
}
