using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    int index;

    public Image progressBar;

    void Awake()
    {
        index = GameData.nextIndex;
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation loadingLevel = SceneManager.LoadSceneAsync(index);
        while (loadingLevel.progress < 1)
        {
            progressBar.fillAmount = loadingLevel.progress;
            yield return null;
        }
        yield return null;
    }
}
