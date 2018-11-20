using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour {

    public static readonly int numeroEsferas = 3;

    //Tipos de esferas
    public GameObject[] esferas;
    //public GameObject esfera1;
    //public GameObject esfera2;
    //public GameObject esfera3;

    public GameObject player;
    
    //Vectores de los tipos de esferas
    GameObject[] vectorObjects = new GameObject[numeroEsferas]; // {esfera1, esfera2...}
    int[] numeroObjects = new int[numeroEsferas];

    float time = 60.0f;
	
    // Use this for initialization
	void Start () {
        
        //Ejecutamos la función repetidamente cada cierto tiempo
        InvokeRepeating("SpawnSphere", time, time);
        player = GameObject.FindGameObjectWithTag("Player");
        inicializacionVectores();

    }

    void inicializacionVectores() {

        for (int i = 0; i < numeroEsferas; i++) {

        }
    }

    //Función que hace spawn de las esferas aleatoriamente
    void SpawnSphere()
    {
        //Numero random para hacer spawn de una esfera aleatoria
        int numero = Random.Range(0, numeroEsferas - 1);

        //Si no hay esfera spawneada de ese tipo
        if (numeroObjects[numero] == 0)
        {

            float xPlayer = player.transform.position.x;
            float zPlayer = player.transform.position.z;

            float x = Random.Range(xPlayer -30.0f, xPlayer + 30.0f);
            float y = 1.0f;
            float minZ = zPlayer - (30 - Mathf.Abs(x)) * -1;
            float maxZ = zPlayer + 30 - Mathf.Abs(x);

            float z = Random.Range(minZ, maxZ);

            Instantiate(vectorObjects[numero], new Vector3(x, y, z), new Quaternion());
            //cantidadEsferas++;
        }

        
    }

    public void esferaDestruida(int cual)
    {
        numeroObjects[cual]--
    }
}
