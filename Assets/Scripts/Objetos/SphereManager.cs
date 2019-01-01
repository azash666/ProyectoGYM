using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour {

    public static GameObject esferaInmune;
    public static GameObject esferaVida;
    public static GameObject esferaVelocidad;

    //Tipo de esferas
    public static GameObject[] tipoEsferas = { esferaInmune, esferaVida, esferaVelocidad };
    public static GameObject player;

    //Número de esferas
    static int numeroEsferas = 3;

    //Vector del número de esferas
    public static int[] numEsferas = new int[numeroEsferas];

    float time = 20.0f;
	
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
        int numero = Random.Range(0, tipoEsferas.Length);

        //Si no hay esfera spawneada de ese tipo
        if (numEsferas[numero] == 0)
        {

            //Obtenemos la posición del player y hacemos spawn dependiendo de su posición
            float xPlayer = player.transform.position.x;
            float zPlayer = player.transform.position.z;

            float x = Random.Range(xPlayer -10.0f, xPlayer + 10.0f);
            float y = 1.0f;
            float minZ = zPlayer - (10 - Mathf.Abs(x)) * -1;
            float maxZ = zPlayer + 10 - Mathf.Abs(x);

            float z = Random.Range(minZ, maxZ);

            Instantiate(tipoEsferas[numero], new Vector3(x, y, z), new Quaternion());
            numEsferas[numero] = 1;
        }
  
    }

    //Si la esfera toca el ambiente la vuelvo hacer respawn
    public static void tocaAmbiente(int cual)
    {
        //Obtenemos la posición del player y hacemos spawn dependiendo de su posición
        float xPlayer = player.transform.position.x;
        float zPlayer = player.transform.position.z;

        float x = Random.Range(xPlayer - 10.0f, xPlayer + 10.0f);
        float y = 1.0f;
        float minZ = zPlayer - (10 - Mathf.Abs(x)) * -1;
        float maxZ = zPlayer + 10 - Mathf.Abs(x);

        float z = Random.Range(minZ, maxZ);

        Instantiate(tipoEsferas[cual], new Vector3(x, y, z), new Quaternion());
    }
}
