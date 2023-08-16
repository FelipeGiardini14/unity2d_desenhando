using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BicVerm : MonoBehaviour
{
    private float vel = 5f;

    public GameObject colisaoOff1;
    public GameObject colisaoOff2;
    public GameObject colisaoOff3;

    public GameObject derrotaUI;
    public GameObject canvasUI;

    private AudioSource[] allAudioSourcesBicVerm;

    void Start()
    {
        colisaoOff();
    }

    void Update()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));

        LimitaRotacao();

        allAudioSourcesBicVerm = FindObjectsOfType<AudioSource>();
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
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        // Linha de chegada
        if (outro.gameObject.CompareTag("Final"))
        {
            derrotaUI.SetActive(true);
            canvasUI.SetActive(false);
            StartCoroutine(PauseCoroutine());
            MuteAllSoundsBicVerm(true);
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
        MuteAllSoundsBicVerm(false);
    }

    private void MuteAllSoundsBicVerm(bool mute)
    {
        foreach (AudioSource audioSourceBicVerm in allAudioSourcesBicVerm)
        {
            if (audioSourceBicVerm != null)
            {
                audioSourceBicVerm.volume = mute ? 0f : 1f;
            }
        }
    }
}
