using ExtraTeypsForBuildingGame;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObeyCostUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        text.text = GetObeyCost();
    }

    string GetObeyCost()
    {
        string result = "";
        string para = "alt�n";
        XData resultXDta = Gamaemenager.Isance.obeyPrices;
        result += "�thalat maliyetleri <br> <br>" +"Enerji  : " +resultXDta.energy + " " + para
        + "<br>"  + "Su      : " + resultXDta.water + " " + para
        + "<br>"  + "G�da    : " + resultXDta.food + " " + para;






        return result;

    }
}
