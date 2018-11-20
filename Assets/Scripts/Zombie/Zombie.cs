using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
    GameObject player;
    private NavMeshAgent nav;
    bool noEncontrado;
    public float distancia, distanciaJugador;
    GameObject destino;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        distanciaJugador = distancia;
        GameObject aux = player;
        if (GameController.vivos.Count > 0) {
            foreach(GameObject vivo in GameController.vivos) {
                if(Vector3.Distance(vivo.transform.position, transform.position) < distancia)
                {
                    distancia = Vector3.Distance(vivo.transform.position, transform.position);
                    aux = vivo;
                }
            }
        }
        destino = aux;
        if (distancia < 6f)
        {
            nav.SetDestination(destino.transform.position);
            noEncontrado = false;
            nav.speed = 3.5f;
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
            GameController.muertos.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
