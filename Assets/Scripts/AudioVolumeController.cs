using UnityEngine;
using UnityEngine.Audio;
public sealed class AudioVolumeController : MonoBehaviour
{


    [SerializeField] AudioMixer _mixer;



    public void Apply(float normalizedVolume,bool soundEnabled)
    {
        float volume = Mathf.Clamp01(normalizedVolume);
        float decibels = soundEnabled ?20f*Mathf.Log10(Mathf.Max(volume,0.0001f)) :80f;

       // if (_mixer ==null || !_mixer.SetFloat("MasterVolume"),decibels)) 
         //   Debug.LogWarning("Could not set MasterVolume");

    }

}
