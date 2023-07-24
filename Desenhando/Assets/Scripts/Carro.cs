using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    public float vel = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
    }
}
