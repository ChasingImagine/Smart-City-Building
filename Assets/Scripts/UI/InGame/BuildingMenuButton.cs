using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenuButton : MonoBehaviour
{
    [SerializeField] List<GameObject> MenuObjects;

    private bool control = false;


    private void Awake()
    {
        foreach (GameObject obj in MenuObjects)
        {
            obj.SetActive(control);
        }
    }

   public void Hiden_UnHiden()
    {
        control = !control;

        foreach (GameObject obj in MenuObjects)
        {
            Gamaemenager.Isance.ispanelActive = control;
            obj.SetActive(control);
        }
    }
}
