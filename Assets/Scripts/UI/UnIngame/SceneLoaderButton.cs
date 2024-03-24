using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderButton : MonoBehaviour
{
    

    public void Load( string screnName)
    {
        SceneManager.LoadScene(screnName);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
