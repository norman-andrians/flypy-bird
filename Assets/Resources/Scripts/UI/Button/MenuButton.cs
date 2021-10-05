using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public PlayerController playerController;

    public void StartButton(bool playing)
    {
        playerController.isPlaying = playing;
        Debug.Log("memulai game");
    }
}
