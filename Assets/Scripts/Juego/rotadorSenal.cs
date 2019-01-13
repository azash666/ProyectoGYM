using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotadorSenal : MonoBehaviour {

    public GameObject objetivo;
    public GameObject senal;

    // Use this for initialization
    // Update is called once per frame
    void Update () {
        Transform target = objetivo.transform;
        Vector3 posicion = new Vector3(target.position.x, transform.position.y, target.position.z);
        Vector3 targetDir = target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 2*3.14159f, 0.5f);
        senal.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
