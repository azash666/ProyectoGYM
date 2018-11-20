using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmuneScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //Destruye la esfera si toca con el ambiente
        if (other.tag == "Enviorament")
        {
            Destroy(this.gameObject);
        }

        //Si es el player se vuelve inmune
        if (other.tag == "Player")
        {
            //Player es el script que ejecutará el player y pondrá el inmune a true
            //other.GetComponentInChildren<Player>().inmuneEnabled = true;

            Destroy(this.gameObject);
        }
    }
}
