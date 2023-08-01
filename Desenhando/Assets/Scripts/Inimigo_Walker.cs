using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Walker : MonoBehaviour
{
    private float vel = 3f;

    public GameObject colisaoOff1;

    void Start()
    {
        Physics2D.IgnoreCollision(colisaoOff1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void Update()
    {
        transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
    }
}
