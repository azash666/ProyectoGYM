using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vivo : MonoBehaviour {
    public float distanciaJugador, distancia;
    GameObject player, aux, destino;
    public GameObject muertoz;
    bool noEncontrado;
    private NavMeshAgent nav;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        distancia = 60;
        distanciaJugador = Vector3.Distance(transform.position, player.transform.position);
        aux = gameObject;
        if (GameController.muertos.Count > 0)
        {
            foreach (GameObject muerto in GameController.muertos)
            {
                if (Vector3.Distance(muerto.transform.position, transform.position) < distancia)
                {
                    distancia = Vector3.Distance(muerto.transform.position, transform.position);
                    aux = muerto;
                }
            }
        }
        destino = aux;
        if (distancia < 7f)
        {
            nav.SetDestination(new Vector3(
                2 * transform.position.x - destino.transform.position.x,
                transform.position.y,
                2 * transform.position.z - destino.transform.position.z
                ));
            noEncontrado = false;
            nav.speed = 3.5f;
        }
        else
        {
            if (!noEncontrado)
            {
                noEncontrado = true;
                nav.speed = Random.Range(2f, 3f);
                nav.SetDestination(new Vector3(transform.position.x + Random.Range(-100f, 100f), transform.position.y, transform.position.z + Random.Range(-100f, 100f)));

            }
        }
        if (distanciaJugador > 25f)
        {
            GameController.vivos.Remove(gameObject);
            Destroy(gameObject);
        }
        /*
        if (distancia < 1)
        {
            GameController.vivos.Remove(gameObject);
            GameObject nuevo = GameObject.Instantiate(muertoz, transform);
            GameController.muertos.Add(nuevo);
            Destroy(gameObject);
        }*/
    }
}
