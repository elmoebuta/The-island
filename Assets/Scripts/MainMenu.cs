using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [Header("Volume Settings")]
    [SerializeField]
    private TMP_Text volumeTextValue = null;

    [SerializeField]
    private Slider volumeSlider = null;

    [SerializeField]
    private GameObject confirmationPrompt = null;

    [SerializeField]
    private float defaultVolumeValue = 1.0f;

    [Header("Gameplay Settings")]
    [SerializeField]
    private TMP_Text controllerSenTextValue = null;

    [SerializeField]
    private Slider controllerSenSlider = null;

    [SerializeField]
    private int defaultSen = 4;

    public int mainControllerSen = 4;

    public void Start()
    {
    }

    public void CargarEscenaJuego(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void salir()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }

    public void setVolumen(float volumen)
    {
        AudioListener.volume = volumen;
        volumeTextValue.text = volumen.ToString("0.0");
    }

    public void VolumeApply()
    {
        StartCoroutine(ConfirmationBox());
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }

    public void ResetButton(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVolumeValue;
            volumeSlider.value = defaultVolumeValue;
            volumeTextValue.text = defaultVolumeValue.ToString("0.0");
            VolumeApply();
        }

        if (MenuType == "GamePlay")
        {
            controllerSenTextValue.text = defaultSen.ToString("0");
            controllerSenSlider.value = defaultSen;
            mainControllerSen = defaultSen;
            GameplayApply();
        }
    }

    public void SetControllerSen(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity);
        controllerSenTextValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply()
    {
        StartCoroutine(ConfirmationBox());
    }
}
