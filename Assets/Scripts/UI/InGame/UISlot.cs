using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] SO_Building so_building;



    
    [SerializeField] Button selectButton;

   

 
    private void Start()
    {
        image.sprite     = so_building.tileSprite;

        nameText.text    = so_building.buildingName;
        description.text = so_building.GetData();

        selectButton.onClick.AddListener(Select);
    }

    void Select()
    {
        Gamaemenager.Isance.selectedBulding = so_building;
    }
}
