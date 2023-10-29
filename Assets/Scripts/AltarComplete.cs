using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarComplete : MonoBehaviour
{
    public GameObject rockPrefab; // Arrastra el objeto de la roca aquí desde el Inspector
    public float activationDistance = 3.0f;

    private bool rocksGenerated = false; // Variable para evitar la generación múltiple de rocas

    private void Update()
    {
        if (rocksGenerated) // Si las rocas ya se generaron, no es necesario comprobar más.
        {
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, activationDistance);
        foreach (Collider collider in colliders)
        {
            
            if (collider.CompareTag("Player") && GameManager.contadorAzul >= 3)
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
            // Ajusta la posición de generación para que las rocas aparezcan en la cima de la montaña.
            Vector3 spawnPosition = new Vector3(transform.position.x + i * 0.5f,
                                                transform.position.y , // Ajusta la altura
                                                transform.position.z  +i * 0.5f);

            Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
