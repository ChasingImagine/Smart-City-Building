using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelecteBuildingdUI : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;


    private void Update()
    {
        image.sprite = Gamaemenager.Isance.selectedBulding.tileSprite;
        text.text = "seçilen <br>" + Gamaemenager.Isance.selectedBulding.buildingName;
    }
}
