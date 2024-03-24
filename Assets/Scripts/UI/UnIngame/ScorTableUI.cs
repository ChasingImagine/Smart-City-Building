using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class ScorTableUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nowText;
    [SerializeField] TextMeshProUGUI bestText;



    private void Start()
    {
        nowText.text = (PlayerPrefs.GetFloat("Now",0f) == 0 ? "Son Oynda dayn�lan g�n sy�s� : -" : ("Son Oynda dayn�lan G�n : " + (int)PlayerPrefs.GetFloat("Now")));
        bestText.text = (PlayerPrefs.GetFloat("Best", 0f) == 0 ? " Dayn�lan eniyi g�nsy�s� : -" : (" Dayn�lan eniyi g�nsy�s� : "  + (int)PlayerPrefs.GetFloat("Now")));
    }
}
