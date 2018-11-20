using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static List<GameObject> muertos;
    public static List<GameObject> vivos;
    public int numVivos = 1;
    public int numZombies = 5;
    public GameObject zombie, vivo;
    GameObject player;

	// Use this for initialization
	void Start () {
        muertos = new List<GameObject>();
        vivos = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnMuertos();
        spawnVivo();
        for (int i = muertos.Count - 1; i >= 0; i--)
        {
            Zombie script = muertos[i].GetComponent<Zombie>();
            script.setDestino(vivoMasCercano(muertos[i]));
            if (script.morir)
            {
                Destroy(muertos[i]);
                muertos.RemoveAt(i);
            }
        }
        for (int i = vivos.Count - 1; i >= 0; i--)
        {
            Vivo script = vivos[i].GetComponent<Vivo>();
            script.setDestino(muertoMasCercano(vivos[i]));
            if (script.convertir)
            {
                GameObject nuevo = Object.Instantiate(zombie, new Vector3(
                    vivos[i].transform.position.x,
                    vivos[i].transform.position.y,
                    vivos[i].transform.position.z), vivos[i].transform.rotation);
                muertos.Add(nuevo);
                script.morir = true;
                numZombies++;
                numVivos--;
            }
            if (script.morir)
            {
                Destroy(vivos[i]);
                vivos.RemoveAt(i);
            }
            
        }
    }

    private void spawnMuertos()
    {
        if (muertos.Count < numZombies)
        {
            int pos = Random.Range(0, 4);
            GameObject nuevo;
            switch (pos)
            {
                case 0:

                    nuevo = Object.Instantiate(zombie, new Vector3(player.transform.position.x + Random.Range(-20f, 20f), player.transform.position.y, player.transform.position.z + 20f), Quaternion.identity);
                    break;
                case 1:

                    nuevo = Object.Instantiate(zombie, new Vector3(player.transform.position.x + Random.Range(-20f, 20f), player.transform.position.y, player.transform.position.z - 20f), Quaternion.identity);
                    break;
                case 2:

                    nuevo = Object.Instantiate(zombie, new Vector3(player.transform.position.x + 20f, player.transform.position.y, player.transform.position.z + Random.Range(-20f, 20f)), Quaternion.identity);
                    break;

                default:
                    nuevo = Object.Instantiate(zombie, new Vector3(player.transform.position.x - 20f, player.transform.position.y, player.transform.position.z + Random.Range(-20f, 20f)), Quaternion.identity);
                    break;
            }
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

                    nuevo = Object.Instantiate(vivo, new Vector3(player.transform.position.x + Random.Range(-25f, 25f), player.transform.position.y, player.transform.position.z + 25f), Quaternion.identity);
                    break;
                case 1:

                    nuevo = Object.Instantiate(vivo, new Vector3(player.transform.position.x + Random.Range(-25f, 25f), player.transform.position.y, player.transform.position.z - 25f), Quaternion.identity);
                    break;
                case 2:

                    nuevo = Object.Instantiate(vivo, new Vector3(player.transform.position.x + 25f, player.transform.position.y, player.transform.position.z + Random.Range(-25f, 25f)), Quaternion.identity);
                    break;

                default:
                    nuevo = Object.Instantiate(vivo, new Vector3(player.transform.position.x - 25f, player.transform.position.y, player.transform.position.z + Random.Range(-25f, 25f)), Quaternion.identity);
                    break;
            }
            vivos.Add(nuevo);
        }
    }

    public GameObject muertoMasCercano(GameObject vivo)
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

    public GameObject vivoMasCercano(GameObject muerto)
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
