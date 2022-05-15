using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseButton;
    public GameObject settingButton;
    public GameObject credits;
    public GameObject pointText;
    public Animator menuAnim;
    public Animator LbbAnim;

    public PlayerController playerController;

    private bool showSetting = false;
    private bool showCredits = false;
    private Animator settingAnim;
    private Animator creditAnim;

    private void Start()
    {
        settingAnim = settingButton.GetComponent<Animator>();
        creditAnim = credits.GetComponent<Animator>();
    }

    public void StartButton(bool playing)
    {
        playerController.isPlaying = playing;
        pointText.SetActive(true);

        LbbAnim.enabled = true;

        StartCoroutine(MulaiGame());
    }

    public void SettingButton()
    {
        if (!showSetting && !playerController.isPlaying)
        {
            StartCoroutine(ShowSetting());
        }
        else
        {
            StartCoroutine(HideSetting());
        }
    }

    public void CreditsButton()
    {
        if (!showCredits && !playerController.isPlaying)
        {
            StartCoroutine(ShowCredits());
        }
        else
        {
            StartCoroutine(HideCredits());
        }
    }


    private IEnumerator MulaiGame()
    {
        menuAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);

        mainMenu.SetActive(false);
        playerController.rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private IEnumerator ShowSetting()
    {
        settingButton.SetActive(true);
        yield return new WaitForSeconds(.25f);
        showSetting = true;
    }

    private IEnumerator HideSetting()
    {
        showSetting = false;
        settingAnim.SetTrigger("Start");
        yield return new WaitForSeconds(.25f);
        settingButton.SetActive(false);
    }

    private IEnumerator ShowCredits()
    {
        credits.SetActive(true);
        yield return new WaitForSeconds(.25f);
        showCredits = true;
    }

    private IEnumerator HideCredits()
    {
        showCredits = false;
        creditAnim.SetTrigger("Start");
        yield return new WaitForSeconds(.25f);
        credits.SetActive(false);
    }
}
