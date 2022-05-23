using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    public GameObject ballGO;       //Balón
    public Transform objTrans;      //Guarda la posición del objetivo
    public float h = 10f;           //Indicamos la máxima altura
    public float gravity = -9.8f;   //Indicamos la gravedad

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            Lanzar();
        }
    }

    void Lanzar() {
        Rigidbody ballRB = ballGO.GetComponent<Rigidbody>();    //Obtenemos el componente del rigid body del balón
        Physics.gravity = Vector3.up * gravity;                 //Asignamos el valor de la gravedad a las propiedades de física de Unity
        ballRB.useGravity = true;                               //Habilitamos la gravedad en el momento en que inicia el lanzamiento
        ballRB.velocity = CalcularVelocidadInicial();           //Calculamos la velocidad inicial
    
        print(ballRB.velocity);                                 //Visualizamos los valores de la velocidad inicial desde la consola
    }

    Vector3 CalcularVelocidadInicial() {
        Vector3 desplazamientoP = objTrans.position - ballGO.transform.position;

        //Calculo de la Velocidad Inicial
        float velocidadY, velocidadX, velocidadZ;

        velocidadY =  Mathf.Sqrt(-2 * gravity * h);
        velocidadX = desplazamientoP.x / ((-velocidadY / gravity) + Mathf.Sqrt(2 * (desplazamientoP.y - h) / gravity)); 
        velocidadZ = desplazamientoP.z / ((-velocidadY / gravity) + Mathf.Sqrt(2 * (desplazamientoP.y - h) / gravity)); 
    
        return new Vector3(velocidadX, velocidadY, velocidadZ);
    }
}