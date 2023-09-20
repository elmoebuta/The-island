using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public GameObject[] npcPrefabs; // Lista de Prefabs de NPC, arrastra todos los modelos aquí
    public int numberOfCopiesPerPrefab = 5; // Número de copias del NPC que deseas crear por cada prefab
    public Terrain terrain; // Arrastra el terreno aquí
    public float maxRadius = 210f; // Radio máximo para la posición x,z
    public float minHeightAboveTerrain = 2f; // Altura mínima sobre el terreno

    void Start()
    {
        // Centro del terreno
        Vector3 terrainCenter = new Vector3(250f, 0f, 250f);

        // Genera las copias del NPC para cada prefab en la lista
        foreach (GameObject npcPrefab in npcPrefabs)
        {
            for (int i = 0; i < numberOfCopiesPerPrefab; i++)
            {
                Vector3 randomOffset = Random.insideUnitCircle * maxRadius;
                Vector3 spawnPosition = terrainCenter + new Vector3(randomOffset.x, 0f, randomOffset.y);
                float terrainHeight = terrain.SampleHeight(spawnPosition);

                // Ajusta la altura de generación para que esté por encima del terreno
                spawnPosition.y = terrainHeight + minHeightAboveTerrain;

                // Instancia el NPC con el modelo seleccionado
                Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
