using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;
    public Button[] botoes;
    public Button botaoContinuar;

    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked_5", 1);
    }

    void Update()
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            if (i + 2 > levelsUnlocked)
                botoes[i].gameObject.SetActive(false);
        }
        if (botaoContinuar != null) 
        {
            if (levelsUnlocked > 1 && levelsUnlocked < 6)
                botaoContinuar.gameObject.SetActive(true);
            else
                botaoContinuar.gameObject.SetActive(false);
        }
    }
}
