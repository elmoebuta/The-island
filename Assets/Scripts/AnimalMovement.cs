using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del animal

    private float targetZPosition; // Posición objetivo en el eje Z para el movimiento

    private void Start()
    {
        SetRandomTargetZPosition(); // Establecer una posición objetivo inicial aleatoria en el eje Z
    }

    private void Update()
    {
        // Calcular la dirección hacia la posición objetivo en el eje Z
        float moveDirectionZ = (targetZPosition - transform.position.z);

        // Invertir la dirección del movimiento en el eje Z
        moveDirectionZ *= -1f;

        // Mover el animal hacia adelante en el eje Z con la velocidad ajustada
        transform.position += new Vector3(0f, 0f, moveDirectionZ) * moveSpeed * Time.deltaTime;

        // Verificar si el animal ha llegado a la posición objetivo en el eje Z
        if (Mathf.Abs(transform.position.z - targetZPosition) < 0.1f)
        {
            // Establecer una nueva posición objetivo aleatoria en el eje Z
            SetRandomTargetZPosition();
        }
    }

    private void SetRandomTargetZPosition()
    {
        // Generar una nueva posición objetivo aleatoria en el eje Z dentro de un rango específico
        float minZ = -10f;
        float maxZ = 10f;

        targetZPosition = Random.Range(minZ, maxZ);
    }
}
