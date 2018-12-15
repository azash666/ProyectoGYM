using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour {

    public int sphereID;
    private SphereManager sphereManager;
    float time = 30.0f;

    private void Start()
    {
        sphereManager = GameObject.Find("SphereManager").GetComponent<SphereManager>();
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time == 0.0)
        {
            sphereManager.esferaDestruida(sphereID);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destruye la esfera si toca con el ambiente y la vuelve a crear
        if (other.tag == "Enviorament")
        {
            sphereManager.tocaAmbiente(0);
            Destroy(this.gameObject);  
        }

        //Destruye la esfera si la coge el player
        if (other.tag == "Player")
        {   
            //falta llamar a la función del player
            sphereManager.esferaDestruida(sphereID);
            Destroy(this.gameObject);
        }
    }
}
