using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisica : MonoBehaviour
{
    public bool pause;
    public Nodo nodoSuperior;
    public Nodo nodoInferior;
    public Resorte resorte;
    public float g = 9.8f;

    public enum Integration
    {
        ExplicitEuler = 0,
        SymplecticEuler = 1,
    }

    public Integration integrationMethod;
    public float h = 0.01f;

    void Start()
    {
        pause = true;
        nodoSuperior.Start();
        nodoInferior.Start();
        resorte.l0 = nodoSuperior.p - nodoInferior.p;
        resorte.l1 = resorte.l0;
        resorte.p = (nodoSuperior.p + nodoInferior.p) / 2f;
    }

    void Update()
    {
       if (Input.GetKeyUp(KeyCode.P)) {
            pause = !pause;
        }
    }

    private void FixedUpdate()
    {
        if (pause)
            return;
        switch (integrationMethod) {
            case Integration.ExplicitEuler:
                integrateExplicitEuler();
                break;
            case Integration.SymplecticEuler:
                integrateSymplecticEuler();
                break;
            default:
                print("¡Error! Método de integración desconocido.");
                break;
        }

        resorte.l1 = nodoSuperior.p - nodoInferior.p;
        resorte.p = (nodoSuperior.p + nodoInferior.p) / 2f;
    }

    void integrateExplicitEuler() {
        float force;
        nodoInferior.p += h * nodoInferior.v;
        force = -nodoInferior.m * g + resorte.k * (resorte.l1 - resorte.l0);
        nodoInferior.v += h * force / nodoInferior.m;
    }

    void integrateSymplecticEuler() {
        float force;
        force = -nodoInferior.m * g + resorte.k * (resorte.l1 - resorte.l0);
        nodoInferior.v += h * force / nodoInferior.m;
        nodoInferior.p += h * nodoInferior.v;
    }
}