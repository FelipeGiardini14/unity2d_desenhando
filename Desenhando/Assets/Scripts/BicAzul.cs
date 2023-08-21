using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BicAzul : MonoBehaviour
{
    private float vel = 4f;
    public Transform bicicleta;

    public GameObject colisaoOff1;
    public GameObject vitoriaUI;
    public GameObject derrotaUI;
    public GameObject canvasUI;

    public Animator animator;
    private bool punicao = false;
    public AudioSource audioSource;

    private AudioSource[] allAudioSourcesBicAzul;

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

        allAudioSourcesBicAzul = FindObjectsOfType<AudioSource>();
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
        // Consequências obstaculos
        if (outro.gameObject.CompareTag("obstaculos1") && transform.position.y < 0.4 && punicao == false)
        {
            punicao = true;
            flip();
            audioSource.Play();
        }
        else if (outro.gameObject.CompareTag("obstaculos1") && transform.position.y < 0.4 && punicao == true)
        {
            punicao = false;
            flip();
            audioSource.Play();
        }
        if (outro.gameObject.CompareTag("obstaculos2") && transform.position.y < -1.7 && punicao == false)
        {
            punicao = true;
            flip();
            audioSource.Play();
        }
        else if (outro.gameObject.CompareTag("obstaculos2") && transform.position.y < -1.7 && punicao == true)
        {
            punicao = false;
            flip();
            audioSource.Play();
        }
        if (outro.gameObject.CompareTag("obstaculos3") && transform.position.y < 3.7 && punicao == false)
        {
            punicao = true;
            flip();
            audioSource.Play();
        }
        else if (outro.gameObject.CompareTag("obstaculos3") && transform.position.y < 3.7 && punicao == true)
        {
            punicao = false;
            flip();
            audioSource.Play();
        }

        if (outro.gameObject.CompareTag("obstaculos_Dead"))
        {
            derrotaUI.SetActive(true);
            canvasUI.SetActive(false);
            StartCoroutine(PauseCoroutine());
            animator.SetTrigger("Dead");
            audioSource.Play();
            MuteAllSoundsBicAzul(true);
        }

        // Linha de chegada
        if (outro.gameObject.CompareTag("Final"))
        {
            vitoriaUI.SetActive(true);
            canvasUI.SetActive(false);
            StartCoroutine(PauseCoroutine());
            MuteAllSoundsBicAzul(true);
            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("levelsUnlocked_5"))
            {
                PlayerPrefs.SetInt("levelsUnlocked_5", SceneManager.GetActiveScene().buildIndex);
            }
        }

        // Flip Scene Menu
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

    // Pausa a cena quando o personagem morre
    private System.Collections.IEnumerator PauseCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 0f;
    }
    // Restaura valor padrão de Time.timeScale, e assim "despausa" a cena quando o script é desabilitado ou quando a cena é alterada
    private void OnDisable()
    {
        Time.timeScale = 1f;
        MuteAllSoundsBicAzul(false);
    }

    private void MuteAllSoundsBicAzul(bool mute)
    {
        foreach (AudioSource audioSourceBicAzul in allAudioSourcesBicAzul)
        {
            if (audioSourceBicAzul != null)
            {
                audioSourceBicAzul.volume = mute ? 0f : 1f;
            }
        }
    }
}
