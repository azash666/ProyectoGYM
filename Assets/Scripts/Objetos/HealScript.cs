using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Entorno")
        {
            //SphereManager.tocaAmbiente(1);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().isHeal = true;
            //SphereManager.numEsferas[1] = 0;
            Destroy(this.gameObject);
        }
    }
}