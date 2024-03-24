using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UpdateMuzicSet : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixerGroup;

    [SerializeField] string muzicAudoGrupName = "Muzic";
    [SerializeField] string efectAudoGrupName = "Efects";

 

    private void Update()
    {
        audioMixerGroup.SetFloat(muzicAudoGrupName, PlayerPrefs.GetFloat(muzicAudoGrupName,0f));
        audioMixerGroup.SetFloat(efectAudoGrupName,PlayerPrefs.GetFloat(efectAudoGrupName,0f));
    }
}
