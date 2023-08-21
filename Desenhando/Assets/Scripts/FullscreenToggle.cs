using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    /*
    private bool isFullscreen = false; // Mantém o estado atual da tela cheia
    private Button toggleButton;
    */

    public Sprite fullscreen;
    public Sprite window;

    private Image buttonImage;
    private bool isFullscreenImage = true;

    private void Start()
    {
        /*
        toggleButton = GetComponent<Button>();
        toggleButton.onClick.AddListener(ToggleFullscreen);
        */////////////

        
        buttonImage = GetComponent<Image>();
        isFullscreenImage = PlayerPrefs.GetInt("ToggleImageState", 1) == 1; // Carrega o estado salvo do PlayerPrefs

        if (isFullscreenImage)
        {
            buttonImage.sprite = fullscreen;
        }
        else
        {
            buttonImage.sprite = window;
        }

        /*
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = fullscreen;
        */
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

        /*
        public void ToggleFullscreen()
        {
            isFullscreen = !isFullscreen; // Alterna o estado da tela cheia

            // Alterna entre tela cheia e janela
            Screen.fullScreen = isFullscreen;
        }
        */
    public void ToggleImage()
    {
        isFullscreenImage = !isFullscreenImage;

        if (isFullscreenImage)
        {
            buttonImage.sprite = fullscreen;
        }
        else
        {
            buttonImage.sprite = window;
        }

        
        // Salva o estado do botão no PlayerPrefs
        PlayerPrefs.SetInt("ToggleImageState", isFullscreenImage ? 1 : 0);
        
    }
}