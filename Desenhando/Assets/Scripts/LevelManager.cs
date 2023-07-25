using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;
    public Button[] botoes;

    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked_3", 1);
        UpdateButtonStates();
    }

    void UpdateButtonStates()
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            if (i + 2 > levelsUnlocked)
            {
                // Desativar o botão e parar a animação (substitua "avancar" pelo nome do Animator do botão)
                botoes[i].gameObject.SetActive(false);
                Animator avancar = botoes[i].GetComponent<Animator>();
                if (avancar != null)
                {
                    avancar.StopPlayback();
                }
            }
            else
            {
                // Ativar o botão e reproduzir a animação (substitua "avancar" pelo nome do Animator do botão)
                botoes[i].gameObject.SetActive(true);
                Animator avancar = botoes[i].GetComponent<Animator>();
                if (avancar != null)
                {
                    avancar.Play("Avancar");
                }
            }
        }
    }

    public void UnlockNextLevel()
    {
        levelsUnlocked++;
        PlayerPrefs.SetInt("levelsUnlocked_3", levelsUnlocked);
        UpdateButtonStates();
    }
}
*/

public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;
    public Button[] botoes;

    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked_3", 1);

        /*
        for (int i=0; i<botoes.Length; i++)
        {
            botoes[i].gameObject.SetActive(false);
            //botoes[i].interactable = false;
        }
        for (int i=0; i<levelsUnlocked; i++)
        {
            botoes[i].gameObject.SetActive(true);
            //botoes[i].interactable = true;
        }
        */
    }

    void Update()
    {

        for (int i = 0; i < botoes.Length; i++)
        {
            if (i + 2 > levelsUnlocked)
            {
                botoes[i].gameObject.SetActive(false);
                //botoes[i].interactable = false;

                //print("pref: " + levelsUnlocked);
                //print("i: " + i);
            }
        }

    }
}
