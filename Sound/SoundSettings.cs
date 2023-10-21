using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/New Sound",fileName = "New Sound"),System.Serializable]
public class SoundSettings : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private AudioClip source;
    [SerializeField] private string tag;
    [SerializeField,Range(0,1)] private float volume = 1;
    [SerializeField,Range(-3,3)] private float pitch = 1;
    [SerializeField,Range(-1,1)] private float stereoPan = 0;
    [SerializeField] private bool loop = true;

    public int Id { get => id; }
    public AudioClip Source { get => source; }
    public string Tag { get => tag;}
    public float Volume { get => volume; }
    public float Pitch { get => pitch;}
    public float StereoPan { get => stereoPan; }
    public bool Loop { get => loop;}


    public float Length => source.length / Pitch;
}