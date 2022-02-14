using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public GameObject player;

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
        playerController = player.GetComponent<PlayerController>();

        pauseButtonAnim = pausedButton.GetComponent<Animator>();
        pauseAnim = pauseObj.GetComponent<Animator>();
        restartAnim = restartObj.GetComponent<Animator>();
    }

    public void OnPaused()
    {
        if (!playerController.isDead && !isPaused)
        {
            StartCoroutine(HidePaudeButton());
            playerController.isPaused = isPaused = true;
        }
    }
    public void UnPaused()
    {
        if (isPaused)
        {
            StartCoroutine(HidePause());
            playerController.isPaused = isPaused = false;
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
        yield return new WaitForSeconds(.8f);
        pauseObj.SetActive(false);
    }

    private IEnumerator Restartgame()
    {
        restartAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
