using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    public GameObject prefabToGenerate;
    public float intervalInSeconds = 10f;

    private void Start()
    {
        InvokeRepeating("GeneratePrefab", 0f, intervalInSeconds);
    }
    private void GeneratePrefab()
    {
        // Determine a posição em que o Prefab será gerado (pode ser a posição atual do gerador ou qualquer outra posição desejada).
        Vector3 spawnPosition = transform.position;

        // Gere o Prefab na posição determinada.
        Instantiate(prefabToGenerate, spawnPosition, Quaternion.identity);
    }
}
