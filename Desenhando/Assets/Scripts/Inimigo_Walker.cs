using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Walker : MonoBehaviour
{
    public float vel = 3f;

    void Update()
    {
        transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
    }
}
