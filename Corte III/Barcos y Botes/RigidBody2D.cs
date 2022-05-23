using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBody2D : MonoBehaviour {
    public float Power = 5f;
    public float MaxSpeed = 10f;

    //Componentes utilizados
    protected Rigidbody Rigidbody;

    public void Awake() {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate() {
        //Vector de calculo
        var forward = Vector3.Scale(new Vector3(1,0,1), transform.forward);

        //Fuerzas de movimiento
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
        } 
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(new Vector3(0f, -30f, 0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            CalcLoads.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed, Power);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            CalcLoads.ApplyForceToReachVelocity(Rigidbody, forward * -MaxSpeed, Power);
        }  
    }
}