using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resorte : MonoBehaviour
{
    public float k = 100f;
    public float l0;
    public float l1;
    public float p;
    public float defaultSize = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, p, transform.position.z);
         transform.localScale = new Vector3(transform.localScale.x, l1 / defaultSize, transform.localScale.z);
    }
}