﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarregaFase : MonoBehaviour
{
    private int sceneToContinue;

    public void Carrega(string Fase)
    {
        SceneManager.LoadScene(Fase);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CarregaContinuar()
    {
        sceneToContinue = PlayerPrefs.GetInt("levelsUnlocked") + 1;
        SceneManager.LoadScene(sceneToContinue);
    }
}
