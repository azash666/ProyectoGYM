using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static List<GameObject> muertos;
    public static List<GameObject> vivos;
    public static float numVivos = 15;
    public static int numZombies = 1;
    public static GameObject zombie, vivo;
    public GameObject zombie2, vivo2;
    static GameObject player;

	// Use this for initialization
	void Start () {
        muertos = new List<GameObject>();
        vivos = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player");
        zombie = zombie2;
        vivo = vivo2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnMuertos();
        spawnVivo();
       
    }

    private void spawnMuertos()
    {
        if (muertos.Count < numZombies)
        {
            int pos = Random.Range(0, 4);
            GameObject nuevo;
            RaycastHit hit;
            Vector3 posicion;
            switch (pos)
            {
                case 0:

                    posicion = new Vector3(player.transform.position.x + Random.Range(-20f, 20f), player.transform.position.y+20f, player.transform.position.z + 20f);
                    break;
                case 1:

                    posicion = new Vector3(player.transform.position.x + Random.Range(-20f, 20f), player.transform.position.y + 20f, player.transform.position.z - 20f);
                    break;
                case 2:

                    posicion = new Vector3(player.transform.position.x + 20f, player.transform.position.y + 20f, player.transform.position.z + Random.Range(-20f, 20f));
                    break;

                default:
                    posicion = new Vector3(player.transform.position.x - 20f, player.transform.position.y + 20f, player.transform.position.z + Random.Range(-20f, 20f));
                    break;
            }
            Ray rayo = new Ray(posicion, Vector3.down);
            if (Physics.Raycast(rayo, out hit))
            {
                /*if (hit.rigidbody != null)
                {*/
                    posicion = hit.point;
                //}
            }
            Debug.Log(posicion);
            nuevo = Object.Instantiate(zombie, posicion, Quaternion.identity);
            muertos.Add(nuevo);
        }
    }

    private void spawnVivo()
    {
        if (vivos.Count < numVivos)
        {
            int pos = Random.Range(0, 4);
            GameObject nuevo;
            switch (pos)
            {
                case 0:

                    nuevo = Object.Instantiate(vivo, new Vector3(player.transform.position.x + Random.Range(-25f, 25f), player.transform.position.y + 0, player.transform.position.z + 25f), Quaternion.identity);
                    break;
                case 1:

                    nuevo = Object.Instantiate(vivo, new Vector3(player.transform.position.x + Random.Range(-25f, 25f), player.transform.position.y + 0, player.transform.position.z - 25f), Quaternion.identity);
                    break;
                case 2:

                    nuevo = Object.Instantiate(vivo, new Vector3(player.transform.position.x + 25f, player.transform.position.y + 0, player.transform.position.z + Random.Range(-25f, 25f)), Quaternion.identity);
                    break;

                default:
                    nuevo = Object.Instantiate(vivo, new Vector3(player.transform.position.x - 25f, player.transform.position.y + 0, player.transform.position.z + Random.Range(-25f, 25f)), Quaternion.identity);
                    break;
            }
            vivos.Add(nuevo);
        }
    }

    public static GameObject muertoMasCercano(GameObject vivo)
    {
        float distancia = 100f;
        GameObject devolver = vivo;
        if (muertos.Count > 0)
        {
            foreach(GameObject muerto in muertos)
            {
                float aux = Vector3.Distance(vivo.transform.position, muerto.transform.position);
                if (aux < distancia)
                {
                    distancia = aux;
                    devolver = muerto;
                }
            }
        }
        if (distancia < 7f) return devolver;
        else return vivo;
    }

    public static GameObject vivoMasCercano(GameObject muerto)
    {
        float distancia = 100f;
        GameObject devolver = muerto;
        if(Vector3.Distance(muerto.transform.position, player.transform.position) < 6)
        {
            distancia = Vector3.Distance(muerto.transform.position, player.transform.position);
            devolver = player;
        }
        if (vivos.Count > 0)
        {
            foreach (GameObject vivo in vivos)
            {
                float aux = Vector3.Distance(muerto.transform.position, vivo.transform.position);
                if (aux < distancia)
                {
                    distancia = aux;
                    devolver = vivo;
                }
            }
        }
        if (distancia < 6f) return devolver;
        else return muerto;
    }


}
