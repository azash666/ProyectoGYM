using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vivo : MonoBehaviour {
    public float distanciaJugador, distancia;
    public GameObject player, aux, destino;
    public GameObject muertoz;
    public bool morir, convertir;
    bool noEncontrado;
    private NavMeshAgent nav;
    Vector3 posicionDestino;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        morir = false;
        convertir = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        distanciaJugador = Vector3.Distance(player.transform.position, transform.position);
        if (destino != gameObject)
        {
            posicionDestino = destino.transform.position;
            nav.SetDestination(new Vector3(
                2 * transform.position.x - posicionDestino.x,
                transform.position.y,
                2 * transform.position.z - posicionDestino.z
                ));
            noEncontrado = false;
            nav.speed = Random.Range(3f, 4f);
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
        if (distanciaJugador > 30f)
        {
            morir = true;
        }
        
        if ((distancia=Vector3.Distance(posicionDestino, transform.position)) < 1 && destino!=gameObject)
        {
            convertir = true;
        }
        
    }

    public void setDestino(GameObject destino)
    {
        this.destino = destino;
    }
}
