using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_3 : MonoBehaviour {
    public Transform Sphere_1;
    public Transform Sphere_2;
    public GameObject Parent;

    float ang = 0.0f;
    float vx1 = 2.0f, vy1 = 2.0f, vx2 = -2.0f, vy2 = -2.0f;
    float px1 = 0.0f, py1 = 0.0f, px2 = 4.0f, py2 = 3.0f;
    float m1 = 1.0f, m2 = 1.0f;
    float e = 1.0f;
    float radio_s = 0.5f;

    public Transform[] spheres;
    public Vector2[] spherePositions;
    public Vector2[] sphereVelocitys;
    public float[] sphereMass;

    void Start() {
        Sphere_1 = this.gameObject.transform.GetChild(0);
        Sphere_2 = this.gameObject.transform.GetChild(1);

        Sphere_1.position = new Vector3(px1, py1, 0);
        Sphere_2.position = new Vector3(px2, py2, 0);
        Sphere_1.GetComponent<Sphere_3>().setVelocidad(new Vector3(vx1, vy1, 0));
        Sphere_2.GetComponent<Sphere_3>().setVelocidad(new Vector3(vx2, vy2, 0));

        Parent = gameObject;
        spheres = new Transform[Parent.transform.childCount];
        for(int i = 0; i < spheres.Length; i++) {
            spheres[i] = Parent.transform.GetChild(i);
            spheres[i].GetComponent<Sphere_3>().setVelocidad(new Vector3(sphereVelocitys[i].x, sphereVelocitys[i].y, 0));
            spheres[i].transform.position = new Vector3(spherePositions[i].x, spherePositions[i].y,0);
        }
    }

    void Update() {
        for(int i = 0; i < spheres.Length; i++) {
            for(int j = 0; j < spheres.Length; j++) {
                if (j != i) {
                    float aux = 1.0f / (sphereMass[i] + sphereMass[j]);
                    float vp1, vn1, vp2, vn2;

                    float distancia = Vector3.Distance(spheres[i].position, spheres[j].position);

                    Vector3 vel1 = spheres[i].GetComponent<Sphere_3>().getVelocidad();
                    Vector3 vel2 = spheres[j].GetComponent<Sphere_3>().getVelocidad();
                    if (distancia <= 2.0 * radio_s) {
                        //Angulo del eje de accion al colisionar
                        ang = Mathf.Atan2(spherePositions[i].y - spherePositions[j].y, spherePositions[i].x - spherePositions[j].x);

                        //Eje de rotacion de la esfera azul
                        vp1 = (vel1.x * Mathf.Cos(ang)) + (vel1.y * Mathf.Sin(ang));
                        vn1 = -(vel1.x * Mathf.Sin(ang)) + (vel1.y * Mathf.Cos(ang));

                        //Eje de rotacion de la esfera blanca
                        vp2 = (vel2.x * Mathf.Cos(ang)) + (vel2.y * Mathf.Sin(ang));
                        vn2 = -(vel2.x * Mathf.Sin(ang)) + (vel2.y * Mathf.Cos(ang));

                        //Volvemos a calcular las velocidades despues de la colision
                        float vp1_new = ((sphereMass[i] - (e * sphereMass[j])) * vp1 * aux) + (((1.0f + e) * sphereMass[j]) * vp2 * aux);
                        float vp2_new = (((1.0f + e) * sphereMass[i]) * vp1 * aux) + ((sphereMass[j] - (e * sphereMass[i])) * vp2 * aux);

                        //Eje de rotacion contrario de la esfera azul
                        sphereVelocitys[i].x = (vp1_new * Mathf.Cos(ang)) - (vn1 * Mathf.Sin(ang));
                        sphereVelocitys[i].y = (vp1_new * Mathf.Sin(ang)) + (vn1 * Mathf.Cos(ang));

                        //Eje de rotacion contrario de la esfera blanca
                        sphereVelocitys[j].x = (vp2_new * Mathf.Cos(ang)) - (vn2 * Mathf.Sin(ang));
                        sphereVelocitys[j].y = (vp2_new * Mathf.Sin(ang)) + (vn2 * Mathf.Cos(ang));

                        //Asignamos las nuevas velocidades a cada esfera
                        spheres[i].GetComponent<Sphere_3>().setVelocidad(new Vector3(sphereVelocitys[i].x, sphereVelocitys[i].y, 0));
                        spheres[j].GetComponent<Sphere_3>().setVelocidad(new Vector3(sphereVelocitys[j].x, sphereVelocitys[j].y, 0));
                    }

                    //Calculamos las posiciones de las esferas en el eje X
                    spherePositions[i].x = spherePositions[i].x + Time.deltaTime * sphereVelocitys[i].x;
                    spherePositions[j].x = spherePositions[j].x + Time.deltaTime * sphereVelocitys[j].x;

                    //Calculamos las posiciones de las esferas en el eje Y
                    spherePositions[i].y = spherePositions[i].y + Time.deltaTime * sphereVelocitys[i].y;
                    spherePositions[j].y = spherePositions[j].y + Time.deltaTime * sphereVelocitys[j].y;

                    //Asignamos las nuevas posiciones a cada esfera
                    spheres[i].position = new Vector3(spherePositions[i].x, spherePositions[i].y, 0);
                    spheres[j].position = new Vector3(spherePositions[j].x, spherePositions[j].y, 0);
                }
            }
        }
    }
}