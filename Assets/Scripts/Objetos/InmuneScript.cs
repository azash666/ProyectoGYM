using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmuneScript : MonoBehaviour {

    SphereManager sm;

    public void Awake()
    {
        sm = GameObject.Find("SphereManager").GetComponent<SphereManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Entorno")
        {
            sm.tocaAmbiente(0);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().isInmune = true;
            sm.numEsferas[0] = 0;
            Destroy(this.gameObject);
        }
    }
}
