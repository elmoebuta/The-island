using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneController : MonoBehaviour
{
    public string sceneLoadName;
    public TextMeshProUGUI textProgress;
    public Slider sliderProgress;
    public float currentPercent;
    private AsyncOperation loadAsync;
    public GameObject slider;
    public GameObject message;

    public IEnumerator LoadScene(string nameToLoad)
    {
        textProgress.text = "Loading.. 00%";
        loadAsync = SceneManager.LoadSceneAsync(nameToLoad);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            currentPercent = loadAsync.progress * 100 / 0.9f;
            textProgress.text = "Loading.." + currentPercent.ToString("00") + "%";
            yield return null;
        }
    }
    void Start()
    {
        StartCoroutine(LoadScene(sceneLoadName));
    }

    // Update is called once per frame
    void Update()
    {
        sliderProgress.value = Mathf.MoveTowards(sliderProgress.value, currentPercent, 10 * Time.deltaTime);
        if (loadAsync != null && currentPercent>=100)
        {
            slider.SetActive(false);
            message.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                loadAsync.allowSceneActivation = true;
                AudioManager.Instance.NextTrack();
            }
        }
    }
}
