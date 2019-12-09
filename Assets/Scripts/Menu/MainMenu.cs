using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider loadingBar;
    public void PlayGame()
    {
        StartCoroutine(Loading());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Loading()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        float progress = Mathf.Clamp01(operation.progress / 0.9f);

        while (operation.isDone == false)
        {
            progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;

            yield return null;
        }
    }
}
