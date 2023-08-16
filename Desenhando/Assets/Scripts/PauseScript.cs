﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private Animator barraAnim;
    private Animator retomarAnim;
    private bool exibir;

    private AudioSource[] allAudioSources;

    private void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

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
            MuteAllSounds(true);
        }
        else
        {
            barraAnim.Play("PauseAnim_Inverso");
            retomarAnim.Play("RetomarAnim_Inverso");
            exibir = false;

            Time.timeScale = 1;
            MuteAllSounds(false);
        }
    }

    public void Carrega(string Fase)
    {
        SceneManager.LoadScene(Fase);
        Time.timeScale = 1;
        MuteAllSounds(false); // Certifique-se de que os sons não permaneçam mutados ao mudar de cena
    }

    private void MuteAllSounds(bool mute)
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = mute ? 0f : 1f;
        }
    }
}
