using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorPrefab : MonoBehaviour
{
    public List<GameObject> prefabsToGenerate;
    public float intervalInSeconds = 5f;

    void Start()
    {
        StartCoroutine(GeneratePrefabsCoroutine());
    }

    private System.Collections.IEnumerator GeneratePrefabsCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalInSeconds);

            // Escolhe aleatoriamente um dos Prefabs da lista.
            int randomIndex = Random.Range(0, prefabsToGenerate.Count);
            GameObject prefabToInstantiate = prefabsToGenerate[randomIndex];

            // Determine a posição em que o Prefab será gerado (pode ser a posição atual do gerador ou qualquer outra posição desejada).
            Vector3 spawnPosition = transform.position;

            // Gera o Prefab na posição determinada.
            Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
        }
    }
}
