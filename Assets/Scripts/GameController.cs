using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static List<GameObject> muertos;
    public GameObject zombie;
    GameObject player;

	// Use this for initialization
	void Start () {
        muertos = new List<GameObject>();

        player = GameObject.FindGameObjectWithTag("Player");
        //Time.fixedDeltaTime = 1f;
    }
	
	// Update is called once per frame
	void Update () {

        if (true)
        {
            if(muertos.Count < 20)
            {
                int pos = Random.Range(0, 4);
                GameObject nuevo;
                switch (pos)
                {
                    case 0:

                        nuevo = Object.Instantiate(zombie, new Vector3(player.transform.position.x + Random.Range(-20f, 20f), player.transform.position.y, player.transform.position.z + 20f), Quaternion.identity);
                        break;
                    case 1:

                        nuevo = Object.Instantiate(zombie, new Vector3(player.transform.position.x + Random.Range(-20f, 20f), player.transform.position.y, player.transform.position.z -20f), Quaternion.identity);
                        break;
                    case 2:

                        nuevo = Object.Instantiate(zombie, new Vector3(player.transform.position.x + 20f, player.transform.position.y, player.transform.position.z + Random.Range(-20f, 20f)), Quaternion.identity);
                        break;

                    default:
                        nuevo = Object.Instantiate(zombie, new Vector3(player.transform.position.x -20f, player.transform.position.y, player.transform.position.z + Random.Range(-20f, 20f)), Quaternion.identity);
                        break;
                }
                 muertos.Add(nuevo);
            }
        }
    }
}
