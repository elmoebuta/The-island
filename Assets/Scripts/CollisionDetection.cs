using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto impactado: " + other.gameObject.name);
        // Puedes agregar aquí cualquier acción que desees realizar cuando algo entre en el collider.
    }
}
