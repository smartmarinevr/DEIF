using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound item in sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;
            item.source.volume = item.volume;

            item.source.pitch = item.pitch;
            item.source.loop = item.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, s => s.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {

        Sound s = System.Array.Find(sounds, s => s.name == name);
        s.source.Stop();
    }
}
