using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Entorno")
        {
            SphereManager.tocaAmbiente(2);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            other.GetComponent<SimpleCharacterControl>().isSpeed = true;
            SphereManager.numEsferas[2] = 0;
            Destroy(this.gameObject);
        }
    }
}