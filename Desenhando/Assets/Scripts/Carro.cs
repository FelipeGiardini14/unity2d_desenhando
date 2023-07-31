using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    private float vel = 8f;
    
    void Update()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
    }
}
