using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaLibre : MonoBehaviour {
    float altura = 211.5f;
    float velocidad = 0.0f;
    float gravedad = 9.81f; 

    void Update() {
        velocidad = velocidad - gravedad * Time.deltaTime;
        Debug.Log("velocidad: " + velocidad);
        altura = altura + velocidad * Time.deltaTime;
        Debug.Log("altura: " + altura);
        transform.position = new Vector3(transform.position.x, altura, 0);
    }
}