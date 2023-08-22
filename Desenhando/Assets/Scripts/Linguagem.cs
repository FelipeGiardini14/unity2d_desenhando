using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

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

        if (isImage1)
        {
            buttonImage.sprite = brasil;
            StartCoroutine(SetLocale(0));
        }
        else
        {
            buttonImage.sprite = inglaterra;
            StartCoroutine(SetLocale(1));
        }
    }

    public void ToggleImage()
    {
        isImage1 = !isImage1;

        if (isImage1)
        {
            buttonImage.sprite = brasil;
            StartCoroutine(SetLocale(0));
        }
        else
        {
            buttonImage.sprite = inglaterra;
            StartCoroutine(SetLocale(1));
        }

        // Salva o estado do botão no PlayerPrefs
        PlayerPrefs.SetInt("ToggleImageState", isImage1 ? 1 : 0);
    }

    IEnumerator SetLocale(int _localeID)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
    }
}
