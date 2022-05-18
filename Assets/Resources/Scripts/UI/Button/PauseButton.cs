using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject player;

    public Button pauseBtn;
    public GameObject pauseObj;
    public GameObject pausedButton;
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject restartObj;

    private bool isPaused = false;
    private PlayerController playerController;
    private Animator pauseButtonAnim;
    private Animator pauseAnim;
    private Animator restartAnim;

    // Start is called before the first frame update
    void Start()
    {
        restartObj.SetActive(true);
        playerController = player.GetComponent<PlayerController>();

        pauseButtonAnim = pausedButton.GetComponent<Animator>();
        pauseAnim = pauseObj.GetComponent<Animator>();
        restartAnim = restartObj.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && playerController.isPlaying)
        {
            OnPaused();
            pauseObj.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && playerController.isPlaying)
        {
            UnPaused();
        }
    }

    public void OnPaused()
    {
        if (!playerController.isDead && !isPaused)
        {
            playerController.isPaused = isPaused = true;
            StartCoroutine(HidePaudeButton());
        }
    }
    public void UnPaused()
    {
        if (isPaused)
        {
            playerController.isPaused = false;
            StartCoroutine(HidePause());
        }
    }

    public void RestartScene()
    {
        StartCoroutine(Restartgame());
    }

    private IEnumerator HidePaudeButton()
    {
        pauseButtonAnim.SetTrigger("Hide");
        yield return new WaitForSeconds(1f);
        pausedButton.SetActive(false);
    }

    private IEnumerator HidePause()
    {
        pauseAnim.SetTrigger("Hide");
        yield return new WaitForSeconds(.5f);

        isPaused = false;
        pauseObj.SetActive(false);
    }

    private IEnumerator Restartgame()
    {
        restartAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
