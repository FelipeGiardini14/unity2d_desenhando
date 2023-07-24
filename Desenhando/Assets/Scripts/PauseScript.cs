using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private Animator barraAnim;
    private Animator retomarAnim;
    private bool exibir;

    public void PauseAnim()
    {
        barraAnim = GameObject.FindGameObjectWithTag("barraAnim").GetComponent<Animator> ();
        retomarAnim = GameObject.FindGameObjectWithTag("retomarAnim").GetComponent<Animator>();

        if (exibir == false)
        {
            barraAnim.Play("PauseAnim");
            retomarAnim.Play("RetomarAnim");
            exibir = true;

            Time.timeScale = 0;
        }
        else
        {
            barraAnim.Play("PauseAnim_Inverso");
            retomarAnim.Play("RetomarAnim_Inverso");
            exibir = false;

            Time.timeScale = 1;
        }
    }

    public void Carrega(string Fase)
    {
        SceneManager.LoadScene(Fase);
        Time.timeScale = 1;
    }
}
