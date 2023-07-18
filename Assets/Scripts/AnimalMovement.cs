using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del animal

    private float targetZPosition; // Posici�n objetivo en el eje Z para el movimiento

    private void Start()
    {
        SetRandomTargetZPosition(); // Establecer una posici�n objetivo inicial aleatoria en el eje Z
    }

    private void Update()
    {
        // Calcular la direcci�n hacia la posici�n objetivo en el eje Z
        float moveDirectionZ = (targetZPosition - transform.position.z);

        // Invertir la direcci�n del movimiento en el eje Z
        moveDirectionZ *= -1f;

        // Mover el animal hacia adelante en el eje Z con la velocidad ajustada
        transform.position += new Vector3(0f, 0f, moveDirectionZ) * moveSpeed * Time.deltaTime;

        // Verificar si el animal ha llegado a la posici�n objetivo en el eje Z
        if (Mathf.Abs(transform.position.z - targetZPosition) < 0.1f)
        {
            // Establecer una nueva posici�n objetivo aleatoria en el eje Z
            SetRandomTargetZPosition();
        }
    }

    private void SetRandomTargetZPosition()
    {
        // Generar una nueva posici�n objetivo aleatoria en el eje Z dentro de un rango espec�fico
        float minZ = -10f;
        float maxZ = 10f;

        targetZPosition = Random.Range(minZ, maxZ);
    }
}
