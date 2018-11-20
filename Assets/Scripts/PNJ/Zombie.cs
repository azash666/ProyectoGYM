using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
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
        morir = false;
    }
	
	// Update is called once per frame
	void Update () {
        distanciaJugador = Vector3.Distance(player.transform.position, transform.position);
        if (destino!=gameObject)
        {
            nav.SetDestination(destino.transform.position);
            noEncontrado = false;
            nav.speed = Random.Range(2.5f,3.5f);
        }
        else
        {
            if (!noEncontrado)
            {
                noEncontrado = true;
                nav.speed = Random.Range(0.5f, 1.5f);
                nav.SetDestination(new Vector3(transform.position.x+Random.Range(-100f, 100f), transform.position.y, transform.position.z + Random.Range(-100f, 100f)));
                
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
