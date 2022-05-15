using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public bool str = false;

    private bool isStarted = false;
    private Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        if (!isStarted && str)
        {
            StartCoroutine(LoadAsynchronously(1));
            isStarted = true;
        }
    }

    IEnumerator LoadAsynchronously (int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
