using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    public Sprite fullscreen;
    public Sprite window;

    private Image buttonImageFull;
    private bool isFullscreenImage = true;

    private void Start()
    {
        buttonImageFull = GetComponent<Image>();
        isFullscreenImage = PlayerPrefs.GetInt("ToggleImageStateFull", 1) == 1; // Carrega o estado salvo do PlayerPrefs

        if (isFullscreenImage)
        {
            buttonImageFull.sprite = window;
        }
        else
        {
            buttonImageFull.sprite = fullscreen;
        }
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ToggleImage()
    {
        isFullscreenImage = !isFullscreenImage;

        if (isFullscreenImage)
        {
            buttonImageFull.sprite = window;
        }
        else
        {
            buttonImageFull.sprite = fullscreen;
        }
        
        // Salva o estado do botão no PlayerPrefs
        PlayerPrefs.SetInt("ToggleImageStateFull", isFullscreenImage ? 1 : 0);
    }
}