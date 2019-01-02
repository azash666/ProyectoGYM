using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmuneScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Entorno")
        {
            //SphereManager.tocaAmbiente(0);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().isInmune = true;
            //SphereManager.numEsferas[0] = 0;
            Destroy(this.gameObject);
        }
    }
}
