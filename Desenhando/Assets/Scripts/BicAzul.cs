using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BicAzul : MonoBehaviour
{
    public float vel = 4f;

    public GameObject colisaoOff1;
    public Transform bicicleta;
    public GameObject vitoriaUI;
    public GameObject derrotaUI;
    public GameObject canvasUI;

    public Animator animator;

    bool punicao = false;

    void Start()
    {
        colisaoOff();
    }

    void Update()
    {
        if (punicao == false)
        {
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));
        }
        if (punicao == true)
        {
            transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
        }

        LimitaRotacao();
    }

    void flip()
    {
        Vector3 scala = bicicleta.localScale;
        scala.x *= -1;
        bicicleta.localScale = scala;
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
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("obstaculos1") && transform.position.y < 0.4 && punicao == false)
        {
            punicao = true;
            flip();
        }
        else if (outro.gameObject.CompareTag("obstaculos1") && transform.position.y < 0.4 && punicao == true)
        {
            punicao = false;
            flip();
        }
        if (outro.gameObject.CompareTag("obstaculos2") && transform.position.y < -1.7 && punicao == false)
        {
            punicao = true;
            flip();
        }
        else if (outro.gameObject.CompareTag("obstaculos2") && transform.position.y < -1.7 && punicao == true)
        {
            punicao = false;
            flip();
        }
        if (outro.gameObject.CompareTag("obstaculos4") && transform.position.y < 3.7 && punicao == false)
        {
            punicao = true;
            flip();
        }
        else if (outro.gameObject.CompareTag("obstaculos4") && transform.position.y < 3.7 && punicao == true)
        {
            punicao = false;
            flip();
        }

        if (outro.gameObject.CompareTag("obstaculos3"))
        {
            derrotaUI.SetActive(true);
            canvasUI.SetActive(false);
            StartCoroutine(PauseCoroutine());

            animator.SetTrigger("Dead");
        }

        // Linha de chegada
        if (outro.gameObject.CompareTag("Final"))
        {
            vitoriaUI.SetActive(true);
            canvasUI.SetActive(false);
            StartCoroutine(PauseCoroutine());
            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("levelsUnlocked_3"))
            {
                PlayerPrefs.SetInt("levelsUnlocked_3", SceneManager.GetActiveScene().buildIndex);
                /*
                vitoriaUI.SetActive(true);
                canvasUI.SetActive(false);
                StartCoroutine(PauseCoroutine());
                */
            }
            /*
            else
            {
                SceneManager.LoadScene("SelectFase_NEW");
            }
            */
        }

        // Flip Menu
        if (outro.gameObject.CompareTag("flipMenu") && punicao == false)
        {
            punicao = true;
            flip();
        }
        else if (outro.gameObject.CompareTag("flipMenu") && punicao == true)
        {
            punicao = false;
            flip();
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
