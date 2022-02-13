using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject pauseButton;
    public Animator menuAnim;

    public PlayerController playerController;

    public void StartButton(bool playing)
    {
        playerController.isPlaying = playing;
        Debug.Log("memulai game");

        StartCoroutine(MulaiGame());
    }

    private IEnumerator MulaiGame()
    {
        menuAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        pauseButton.SetActive(true);
        playerController.rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
