using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour {

    public GameObject esferaInmune;
    public GameObject esferaVida;
    public GameObject esferaVelocidad;


    public static readonly int numeroEsferas = 3;

    //Tipo de esferas
    public GameObject[] esferas;
    public GameObject player;
    
    //Vector del número de esferas
    int[] numeroObjects = new int[numeroEsferas];

    float time = 60.0f;
	
    // Use this for initialization
	void Start () {
        
        //Ejecutamos la función repetidamente cada cierto tiempo
        InvokeRepeating("SpawnSphere", time, time);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //Función que hace spawn de las esferas aleatoriamente
    void SpawnSphere()
    {
        //Numero random para hacer spawn de una esfera aleatoria
        int numero = Random.Range(0, numeroEsferas - 1);

        //Si no hay esfera spawneada de ese tipo
        if (numeroObjects[numero] == 0)
        {

            //Obtenemos la posición del player y hacemos spawn dependiendo de su posición
            float xPlayer = player.transform.position.x;
            float zPlayer = player.transform.position.z;

            float x = Random.Range(xPlayer -30.0f, xPlayer + 30.0f);
            float y = 1.0f;
            float minZ = zPlayer - (30 - Mathf.Abs(x)) * -1;
            float maxZ = zPlayer + 30 - Mathf.Abs(x);

            float z = Random.Range(minZ, maxZ);

            //Instantiate(esferas[numero], new Vector3(x, y, z), new Quaternion());
            numeroObjects[numero] = 1;
        }
  
    }

    //Si la esfera toca el ambiente la vuelvo hacer respawn
    public void tocaAmbiente(int cual)
    {
        //Obtenemos la posición del player y hacemos spawn dependiendo de su posición
        float xPlayer = player.transform.position.x;
        float zPlayer = player.transform.position.z;

        float x = Random.Range(xPlayer - 30.0f, xPlayer + 30.0f);
        float y = 1.0f;
        float minZ = zPlayer - (30 - Mathf.Abs(x)) * -1;
        float maxZ = zPlayer + 30 - Mathf.Abs(x);

        float z = Random.Range(minZ, maxZ);

        Instantiate(esferas[cual], new Vector3(x, y, z), new Quaternion());
    }

    public void esferaDestruida(int cual)
    {
        numeroObjects[cual]--;
    }
}
