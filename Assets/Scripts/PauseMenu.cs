using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;

    public GameObject basicUI;

    public GameObject pauseUI;

    public GameObject player;

    public void Pause()
    {
        if (isPaused)
        {
            if (pauseUI.activeSelf)
            {
                isPaused = false;
                pauseUI.SetActive(false);
                basicUI.SetActive(true);
                Time.timeScale = 1;
                player.GetComponent<PlayerInput>().SetInput(true);
                player.GetComponent<RewindMotion>().SetInput(true);
                player.transform.Find("Body").gameObject.GetComponent<RewindMotion>().SetInput(true);
                GameObject.Find("View").GetComponent<RotateInput>().SetInput(true);
                GameObject.Find("View").GetComponent<RewindMotion>().SetInput(true);
            }
        }
        else
        {
            if (basicUI.activeSelf)
            {
                isPaused = true;
                basicUI.SetActive(false);
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                player.GetComponent<PlayerInput>().SetInput(false);
                player.GetComponent<RewindMotion>().SetInput(false);
                player.transform.Find("Body").gameObject.GetComponent<RewindMotion>().SetInput(false);
                GameObject.Find("View").GetComponent<RotateInput>().SetInput(false);
                GameObject.Find("View").GetComponent<RewindMotion>().SetInput(false);
            }
        }
    }
}
