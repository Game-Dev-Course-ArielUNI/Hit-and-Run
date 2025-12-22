using Unity.VisualScripting;
using UnityEngine;

public class AudioManeger : MonoBehaviour
{
    public sounds[] sounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isloop;
        }
        playsound("mainTHeme");
    }
    public void playsound(string name)
    {
        foreach (sounds s in sounds)
        {
            if (s.name == name)
            {
                s.source.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
