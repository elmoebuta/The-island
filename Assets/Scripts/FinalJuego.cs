using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.ChangeMusic(3);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void salir()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
