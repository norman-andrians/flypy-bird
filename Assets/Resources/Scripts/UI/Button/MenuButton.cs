using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject invExit;
    public GameObject mainMenu;
    public GameObject pauseButton;
    public GameObject settingButton;
    public GameObject exit;
    public GameObject credits;
    public GameObject pointField;
    public Animator menuAnim;
    public Animator LbbAnim;

    public PlayerController playerController;

    private bool showSetting = false;
    private bool showCredits = false;
    private bool showExit = false;

    private Animator settingAnim;
    private Animator creditAnim;
    private Animator exitAnim;

    private Button visb;

    private void Start()
    {
        settingAnim = settingButton.GetComponent<Animator>();
        creditAnim = credits.GetComponent<Animator>();
        exitAnim = exit.GetComponent<Animator>();

        visb = invExit.GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !playerController.isPlaying)
        {
            ExitButton();
        }
    }

    public void StartButton(bool playing)
    {
        if (showSetting) StartCoroutine(HideSetting());
        if (showCredits) StartCoroutine(HideCredits());

        playerController.isPlaying = playing;
        pointField.SetActive(true);

        LbbAnim.enabled = true;

        StartCoroutine(MulaiGame());

    }

    public void SettingButton()
    {
        if (!showSetting && !playerController.isPlaying)
        {
            if (!showCredits && !showExit) StartCoroutine(ShowSetting());
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
            if (!showSetting && !showExit) StartCoroutine(ShowCredits());
        }
        else
        {
            StartCoroutine(HideCredits());
        }
    }

    public void ExitButton()
    {
        if (!showExit && !playerController.isPlaying)
        {
            if (!showSetting && !showCredits) StartCoroutine(ShowExit());
        }
        else
        {
            StartCoroutine(HideExit());
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HideAll()
    {
        if (showSetting) StartCoroutine(HideSetting());
        if (showCredits) StartCoroutine(HideCredits());
        if (showExit) StartCoroutine(HideExit());
    }


    private IEnumerator MulaiGame()
    {
        menuAnim.enabled = true;
        yield return new WaitForSeconds(1f);

        mainMenu.SetActive(false);
        playerController.rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private IEnumerator ShowSetting()
    {
        invExit.SetActive(true);
        settingButton.SetActive(true);

        yield return new WaitForSeconds(.3f);
        showSetting = true;
    }

    private IEnumerator HideSetting()
    {
        invExit.SetActive(false);
        showSetting = false;

        settingAnim.SetTrigger("Start");
        yield return new WaitForSeconds(.3f);
        settingButton.SetActive(false);
    }

    private IEnumerator ShowCredits()
    {
        invExit.SetActive(true);
        credits.SetActive(true);

        yield return new WaitForSeconds(.3f);
        showCredits = true;
    }

    private IEnumerator HideCredits()
    {
        invExit.SetActive(false);
        showCredits = false;
        creditAnim.SetTrigger("Start");
        yield return new WaitForSeconds(.3f);
        credits.SetActive(false);
    }

    private IEnumerator ShowExit()
    {
        invExit.SetActive(true);
        exit.SetActive(true);

        yield return new WaitForSeconds(.3f);
        showExit = true;
    }
    private IEnumerator HideExit()
    {
        invExit.SetActive(false);
        showExit = false;
        exitAnim.SetTrigger("Start");
        yield return new WaitForSeconds(.3f);
        exit.SetActive(false);
    }
}
