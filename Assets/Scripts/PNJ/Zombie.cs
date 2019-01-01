using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
    public Animator animator;
    GameObject player;
    private NavMeshAgent nav;
    bool noEncontrado;
    public bool morir;
    public float distancia, distanciaJugador;
    GameObject destino;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        morir = false;
    }
	
	// Update is called once per frame
	void Update () {
        setDestino(GameController.vivoMasCercano(gameObject));
        if (morir)
        {
            Destroy(gameObject);
            GameController.muertos.Remove(gameObject);
        }
        else
        {
            distanciaJugador = Vector3.Distance(player.transform.position, transform.position);
            if (destino != gameObject)
            {
                nav.SetDestination(destino.transform.position);
                noEncontrado = false;
                nav.speed = Random.Range(10f, 14f) / 4f;
                animator.SetFloat("MoveSpeed", nav.speed);
            }
            else
            {
                if (!noEncontrado)
                {
                    nav.SetDestination(new Vector3(transform.position.x + Random.Range(-100f, 100f), transform.position.y, transform.position.z + Random.Range(-100f, 100f)));
                    noEncontrado = true;
                    nav.speed = Random.Range(2f, 6f) / 4f;
                    animator.SetFloat("MoveSpeed", nav.speed);
                }
            }
        }
        if (distanciaJugador > 25f) {
            morir = true;
        }
    }

    public void setDestino(GameObject destino)
    {
        this.destino = destino;
    }
}
