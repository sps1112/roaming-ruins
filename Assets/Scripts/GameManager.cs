using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int gold = 0;

    public GameObject basicUI;

    public GameObject endUI;

    public GameObject deathUI;

    void Start()
    {
        GetComponent<UIManager>().SetGoldText();
    }

    public void EndLevel()
    {
        basicUI.SetActive(false);
        endUI.SetActive(true);
        GameObject player = GameObject.FindWithTag("Player");
        player.SetActive(false);
        player.GetComponent<PlayerInput>().SetInput(false);
        player.GetComponent<RewindMotion>().SetInput(false);
        player.transform.Find("Body").gameObject.GetComponent<RewindMotion>().SetInput(false);
        player.transform.Find("Body").gameObject.SetActive(false);
        GameObject.Find("View").GetComponent<RotateInput>().SetInput(false);
        GameObject.Find("View").GetComponent<RewindMotion>().SetInput(false);
    }

    public void ShowDeath()
    {
        basicUI.SetActive(false);
        deathUI.SetActive(true);
        GameObject.Find("View").GetComponent<RotateInput>().SetInput(false);
        GameObject.Find("View").GetComponent<RewindMotion>().SetInput(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        LoadScene(index);
    }

    public void NextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        index %= SceneManager.sceneCountInBuildSettings;
        LoadScene(index);
    }

    void LoadScene(int index)
    {
        gold = 0;
        GameData.nextIndex = index;
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        LoadScene(0);
    }
}
