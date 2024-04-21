using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }



    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public void StopAll()
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.Stop();
        }
    }
 

    public IEnumerator stopFade(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        while (s.source.volume > 0)
        {
            s.source.volume -= 0.5f * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator grav(string name)
    {
        Debug.Log("method working");
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        while (s.source.pitch > 0.5f)
        {
            s.source.pitch -= 0.5f * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator gravInv(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        while (s.source.pitch < 1)
        {
            s.source.pitch += 0.5f * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }
}
