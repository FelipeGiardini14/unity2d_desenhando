using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linguagem : MonoBehaviour
{
    public Sprite brasil;
    public Sprite inglaterra;

    private Image buttonImage;
    private bool isImage1 = true;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        isImage1 = PlayerPrefs.GetInt("ToggleImageState", 1) == 1; // Carrega o estado salvo do PlayerPrefs
        //buttonImage.sprite = brasil;

        if (isImage1)
        {
            buttonImage.sprite = brasil;
        }
        else
        {
            buttonImage.sprite = inglaterra;
        }
    }

    public void ToggleImage()
    {
        isImage1 = !isImage1;

        if (isImage1)
        {
            buttonImage.sprite = brasil;
        }
        else
        {
            buttonImage.sprite = inglaterra;
        }

        // Salva o estado do botão no PlayerPrefs
        PlayerPrefs.SetInt("ToggleImageState", isImage1 ? 1 : 0);
    }
}
