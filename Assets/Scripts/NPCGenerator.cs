using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    public GameObject npcPrefab; // Arrastra el Prefab del NPC aquí
    public int numberOfNPCs = 100; // Número de copias del NPC que deseas crear
    public Terrain terrain; // Arrastra el terreno aquí
    public float maxRadius = 210f; // Radio máximo para la posición x,z

    void Start()
    {
        // Centro del terreno
        Vector3 terrainCenter = new Vector3(250f, 0f, 250f);

        // Genera las copias del NPC
        for (int i = 0; i < numberOfNPCs; i++)
        {
            Vector3 randomOffset = Random.insideUnitCircle * maxRadius;
            Vector3 spawnPosition = terrainCenter + new Vector3(randomOffset.x, 0f, randomOffset.y);
            float terrainHeight = terrain.SampleHeight(spawnPosition);
            spawnPosition.y = terrainHeight;
            Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
