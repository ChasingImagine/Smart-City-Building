using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDestroyed : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
