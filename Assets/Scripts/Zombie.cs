using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
    GameObject player;
    private NavMeshAgent nav;
    bool noEncontrado;
    public float distancia;
    GameObject destino;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        GameObject aux = player;
       
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
        if (distancia > 20f) {
            GameController.muertos.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
