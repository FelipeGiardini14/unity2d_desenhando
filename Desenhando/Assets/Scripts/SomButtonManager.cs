using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomButtonManager : MonoBehaviour
{
    public GameObject music;
    public GameObject sfx;

    private bool isActive = false;

    public void ToggleObjectActivation()
    {
        isActive = !isActive;
        music.SetActive(isActive);
        sfx.SetActive(isActive);
    }
}
