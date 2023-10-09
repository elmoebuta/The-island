using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionMusica : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.ChangeMusic(2);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.ChangeMusic(0);
        }
    }

}
