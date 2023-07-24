using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarregaFase : MonoBehaviour
{
    public void Carrega(string Fase)
    {
        SceneManager.LoadScene(Fase);
    }
}
