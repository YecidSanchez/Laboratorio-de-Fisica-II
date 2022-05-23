using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    public float m = 5f; //Masa
    public float p; //Posición
    public float v; //Velocidad

    public void Start()
    {
       p = transform.position.y; 
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, p, transform.position.z);
    }
}
/*
    // Update is called once per frame
    void Update()
    {
        //El valor de la pos se calcula en el script physicalmanager segun el método
        transform.position = new Vector3(transform.position.x, pos, transform.position.z);
    }
}
*/