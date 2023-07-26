using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BicVerm : MonoBehaviour
{
    public float vel = 5f;

    public GameObject colisaoOff1;
    public GameObject colisaoOff2;
    public GameObject colisaoOff3;
    public GameObject colisaoOff4;
    public GameObject colisaoOff5;

    public GameObject derrotaUI;
    public GameObject canvasUI;

    void Start()
    {
        colisaoOff();
    }

    void Update()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));

        LimitaRotacao();
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

    void colisaoOff()
    {
        Physics2D.IgnoreCollision(colisaoOff1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(colisaoOff2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(colisaoOff3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(colisaoOff4.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(colisaoOff5.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        // Linha de chegada
        if (outro.gameObject.CompareTag("Final"))
        {
            //SceneManager.LoadScene("Menu");
            derrotaUI.SetActive(true);
            canvasUI.SetActive(false);
            StartCoroutine(PauseCoroutine());
        }
    }

    private System.Collections.IEnumerator PauseCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        // Restaura o valor padrão de Time.timeScale quando o script é desabilitado ou quando a cena é alterada
        Time.timeScale = 1f;
    }
}
