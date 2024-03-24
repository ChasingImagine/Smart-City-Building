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
        string para = "altýn";
        XData resultXDta = Gamaemenager.Isance.obeyPrices;
        result += "Ýthalat maliyetleri <br> <br>" +"Enerji  : " +resultXDta.energy + " " + para
        + "<br>"  + "Su      : " + resultXDta.water + " " + para
        + "<br>"  + "Gýda    : " + resultXDta.food + " " + para;






        return result;

    }
}
