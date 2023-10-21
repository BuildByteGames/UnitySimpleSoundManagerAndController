using System.Collections;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    public int SoundID { get => soundSettings.Id; private set{}}
    public AudioSource AudioSource {get
    {
        if(_audioSource == null) _audioSource = GetComponent<AudioSource>();
        return _audioSource;
    }}

    private AudioSource _audioSource;
    private SoundSettings soundSettings;

    internal void PlaySound()
    {
        AudioSource.Play();
        if(soundSettings.Loop == false) StartCoroutine(nameof(AutoStop));
    }

    internal void SetNewSound(SoundSettings soundSettings)
    {
        this.soundSettings = soundSettings;
        UpdateSoundSettings();
    }

    private void UpdateSoundSettings()
    {   
        SoundID = soundSettings.Id;
        AudioSource.clip = soundSettings.Source;
        AudioSource.volume = soundSettings.Volume;
        AudioSource.pitch = soundSettings.Pitch;
        AudioSource.panStereo = soundSettings.StereoPan;
        AudioSource.loop = soundSettings.Loop;
    }

    internal void StopSound()
    {
        AudioSource.Stop();
        Destroy(this.gameObject);
    }

    private IEnumerator AutoStop()
    {
        yield return new WaitForSeconds(soundSettings.Length);
        Manager.SoundManager.Stop(SoundID);
    }
}
