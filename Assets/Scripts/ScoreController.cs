using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI skorKiri;
    public TextMeshProUGUI skorKanan;

    public ScoreManager manager;

    // Update is called once per frame
    void Update()
    {
        skorKiri.text = manager.leftScore.ToString();
        skorKanan.text = manager.rightScore.ToString();
    }
}
