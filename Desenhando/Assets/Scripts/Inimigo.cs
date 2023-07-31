using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private float vel = 3f;
    public Transform inimigo;

    public GameObject colisaoOff1;

    private bool punicao = false;


    void Start()
    {
        colisaoOff();
    }

    void Update()
    {
        if (punicao == false)
        {
            transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
        }
        if (punicao == true)
        {
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));
        }

        LimitaRotacao();
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("obstaculos3") && transform.position.y < 3.7 && punicao == false)
        {
            punicao = true;
            flip();
        }
        else if (outro.gameObject.CompareTag("obstaculos3") && transform.position.y < 3.7 && punicao == true)
        {
            punicao = false;
            flip();
        }
    }

    void flip()
    {
        Vector3 scala = inimigo.localScale;
        scala.x *= -1;
        inimigo.localScale = scala;
    }

    void colisaoOff()
    {
        Physics2D.IgnoreCollision(colisaoOff1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void LimitaRotacao()
    {
        Vector3 euler = transform.eulerAngles;
        if (euler.z > 180)
        {
            euler.z = euler.z - 360;
        }
        euler.z = Mathf.Clamp(euler.z, -45, 45);
        transform.eulerAngles = euler;
    }
}
