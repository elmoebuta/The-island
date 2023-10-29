using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarComplete : MonoBehaviour
{
    public GameObject rockPrefab; // Arrastra el objeto de la roca aquí desde el Inspector
    public float activationDistance = 3.0f;

    private bool rocksGenerated = false; // Variable para evitar la generación múltiple de rocas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !rocksGenerated && GameManager.contadorAzul == 3)
        {
            if (IsPlayerInRange())
            {
                GenerateRocks();
                rocksGenerated = true; // Marca que las rocas ya se han generado
            }
        }
    }

    void GenerateRocks()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, i, 0);
            Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
        }
    }

    bool IsPlayerInRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= activationDistance;
        }
        return false;
    }
}
