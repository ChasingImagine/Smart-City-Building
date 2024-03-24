using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayeUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dayeText;


    private void Update()
    {
        dayeText.text =  Gamaemenager.Isance.daye + ". Gün";
    }
}
