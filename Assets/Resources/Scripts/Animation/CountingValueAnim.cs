using System.Collections;
using UnityEngine;
using TMPro;

public class CountingValueAnim : MonoBehaviour
{
    public Player playerDat;
    public GameObject player;
    public TextMeshProUGUI[] text;

    private int[] maxVal;
    private PlayerController playerController;

    private void Start()
    {
        maxVal = new int[text.Length];

        playerController = player.GetComponent<PlayerController>();

            maxVal[0] = playerDat.point;
            maxVal[1] = playerDat.bestPoint;

            for (int i = 0; i < text.Length; i++)
            {
                CountingValue(text[i], maxVal[i], .05f);
            }
    }

    public void CountingValue(TextMeshProUGUI _text, int _max, float _time)
    {
        StartCoroutine(CountAnim(_text, _max, _time));
    }

    private IEnumerator CountAnim(TextMeshProUGUI text, int max, float t)
    {
        int value = int.Parse(text.text);

        while (value < max)
        {
            yield return new WaitForSeconds(t);
            value++;
        }
    }
}
