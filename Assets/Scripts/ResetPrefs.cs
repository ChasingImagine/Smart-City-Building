using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefs : MonoBehaviour
{
    [SerializeField]bool control = true;
    private void Start()
    {
        if (control) PlayerPrefs.DeleteAll();
    }
}
