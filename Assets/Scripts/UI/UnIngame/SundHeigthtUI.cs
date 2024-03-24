using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SundHeigthtUI : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixerGroup;
    [SerializeField] string MixergrubName;
    [SerializeField] Slider volumeSlider; 



    public void SundSet()
    {
        Debug.Log("harhket");
        audioMixerGroup.SetFloat(MixergrubName, volumeSlider.value);
        PlayerPrefs.SetFloat(MixergrubName, volumeSlider.value);
    }
}
