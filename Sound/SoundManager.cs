using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] string SoundPrefix = "Playing Sound ID:";
    [SerializeField] private List<SoundController> currentlyPlayingSounds = new List<SoundController>();
    private List<SoundSettings> _allSound = new List<SoundSettings>();
    private AudioListener _audioListener;

    private void Awake()
    {
        _audioListener = GetComponent<AudioListener>();
        LoadAllSounds();
    }

    private void LoadAllSounds()
    {
        List<SoundSettings> allGameSounds = Resources.LoadAll<SoundSettings>("").ToList();
        _allSound = allGameSounds.Distinct().ToList();
    }

    public void Play(int id)
    {
        if(_audioListener == null) return;

        SoundSettings sound = _allSound.FirstOrDefault(x =>x.Id == id);
        GameObject newSound = new GameObject($"{SoundPrefix}{id}",typeof(SoundController));
        newSound.transform.SetParent(this.transform);

        SoundController newSoundController = newSound.GetComponent<SoundController>();
        newSoundController.SetNewSound(sound);
        currentlyPlayingSounds.Add(newSoundController);
        newSoundController.PlaySound();
    }

    public void Stop(int id)
    {
        SoundController soundToStop = currentlyPlayingSounds.FirstOrDefault(x => x.SoundID == id);
        if(soundToStop == null) return;
        soundToStop.StopSound();
    }

    public void StopAllSounds(int id)
    {
        foreach(var sound in currentlyPlayingSounds)
        {
            Stop(sound.SoundID);
        }
    }
}

