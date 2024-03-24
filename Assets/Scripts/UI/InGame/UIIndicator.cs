using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIIndicator : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI energyText;
    [SerializeField] TextMeshProUGUI waterText;
    [SerializeField] TextMeshProUGUI foodText;
    [SerializeField] TextMeshProUGUI personText;



    private void FixedUpdate()
    {
        moneyText.text  = Gamaemenager.Isance.source.value.money.ToString("F2");
        energyText.text = Gamaemenager.Isance.source.value.energy.ToString("F2");
        waterText.text  = Gamaemenager.Isance.source.value.water.ToString("F2");
        foodText.text   = Gamaemenager.Isance.source.value.food.ToString("F2");
        personText.text = Gamaemenager.Isance.source.value.person.ToString("F2");
    }

}
