using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto impactado: " + other.gameObject.name);
        // Puedes agregar aqu� cualquier acci�n que desees realizar cuando algo entre en el collider.
    }
}
