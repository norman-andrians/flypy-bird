using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointText : MonoBehaviour
{
    public Player playerDat;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = playerDat.point.ToString();
    }
}
