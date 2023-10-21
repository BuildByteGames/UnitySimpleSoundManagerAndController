using UnityEngine;

public class Manager : MonoBehaviour
{
    private static SoundManager _soundManager;
    public static SoundManager SoundManager {get
    { 
        if(_soundManager == null) _soundManager = FindAnyObjectByType<SoundManager>();
        return _soundManager;
    }}
}
