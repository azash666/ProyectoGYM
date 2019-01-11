using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour {

    public GameObject esferaInmune;
    public GameObject esferaVida;
    public GameObject esferaVelocidad;

    //Tipo de esferas
    private GameObject[] tipoEsferas = new GameObject[3];
    private GameObject player;

    //Vector del número de esferas
    public int[] numEsferas = new int[3];

    float time = 1.0f;
	
    // Use this for initialization
	void Start () {
        
        //Ejecutamos la función repetidamente cada cierto tiempo
        InvokeRepeating("SpawnSphere", time, time);
        player = GameObject.FindGameObjectWithTag("Player");
        tipoEsferas[0] = esferaInmune;
        tipoEsferas[1] = esferaVida;
        tipoEsferas[2] = esferaVelocidad;
        numEsferas[0] = 0;
        numEsferas[1] = 0;
        numEsferas[2] = 0;
    }

    //Función que hace spawn de las esferas aleatoriamente
    void SpawnSphere()
    {
        //Numero random para hacer spawn de una esfera aleatoria
        int numero = Random.Range(0, tipoEsferas.Length);

        //Si no hay esfera spawneada de ese tipo
        if (numEsferas[numero] == 0)
        {

            //Obtenemos la posición del player y hacemos spawn dependiendo de su posición
            float xPlayer = player.transform.position.x;
            float zPlayer = player.transform.position.z;

            float x = Random.Range(xPlayer -10.0f, xPlayer + 10.0f);
            float y = 0.8f;
            float z = Random.Range(zPlayer - 10.0f, zPlayer + 10.0f);

            Instantiate(tipoEsferas[numero], new Vector3(x, y, z), new Quaternion());
            numEsferas[numero] = 1;
        }
  
    }

    //Si la esfera toca el ambiente la vuelvo hacer respawn
    public void tocaAmbiente(int cual)
    {
        //Obtenemos la posición del player y hacemos spawn dependiendo de su posición
        float xPlayer = player.transform.position.x;
        float zPlayer = player.transform.position.z;

        float x = Random.Range(xPlayer - 10.0f, xPlayer + 10.0f);
        float y = 0.8f;
        float z = Random.Range(zPlayer - 10.0f, zPlayer + 10.0f);

        Instantiate(tipoEsferas[cual], new Vector3(x, y, z), new Quaternion());
    }
}
