using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour{

    public Sound[] sounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }

        string currentScene = SceneManager.GetActiveScene().name;
    }

    public void PlaySound(string name){
        foreach(Sound s in sounds){
            if(s.name == name){
                s.source.Play();
            }
        }
    }
}
