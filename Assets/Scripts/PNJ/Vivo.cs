using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vivo : MonoBehaviour {
    public Animator animator;
    public float distanciaJugador, distancia;
    public GameObject player, aux, destino;
    public GameObject muertoz;
    public bool morir, convertir;
    bool noEncontrado;
    private NavMeshAgent nav;
    Vector3 posicionDestino;
    public int probabilidad;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        morir = false;
        convertir = false;
        probabilidad = Random.Range(5, 20)+ Random.Range(5, 20);
    }


    // Update is called once per frame
    void Update ()
    {
        setDestino(GameController.muertoMasCercano(gameObject));
        if (convertir)
        {
            GameObject nuevo = Object.Instantiate(GameController.zombie, new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z), gameObject.transform.rotation);
            GameController.muertos.Add(nuevo);
            morir = true;
            GameController.numZombies++;
            GameController.numVivos-=0.5f;
        }
        if (morir)
        {
            Destroy(gameObject);
            GameController.vivos.Remove(gameObject);
        }


        distanciaJugador = Vector3.Distance(player.transform.position, transform.position);
        if (!morir && !convertir)
        {
            if (destino != gameObject)
            {
                posicionDestino = destino.transform.position;
                nav.SetDestination(new Vector3(
                    2 * transform.position.x - posicionDestino.x,
                    transform.position.y,
                    2 * transform.position.z - posicionDestino.z
                    ));
                noEncontrado = false;
                nav.speed = Random.Range(12f, 16f) / 4f;
                animator.SetFloat("MoveSpeed", nav.speed);
            }
            else
            {
                if (!noEncontrado)
                {
                    noEncontrado = true;
                    nav.SetDestination(new Vector3(transform.position.x + Random.Range(-100f, 100f), transform.position.y, transform.position.z + Random.Range(-100f, 100f)));
                    nav.speed = Random.Range(8f, 12f) / 4f;
                    animator.SetFloat("MoveSpeed", nav.speed);
                }
            }
        }
        if (distanciaJugador > 30f)
        {
            morir = true;
        }
        
        if ((distancia=Vector3.Distance(posicionDestino, transform.position)) < 1 && destino!=gameObject)
        {
            GameController.encuentro(gameObject, destino, probabilidad);
        }
    }

    public void setDestino(GameObject destino)
    {
        this.destino = destino;
    }
}
