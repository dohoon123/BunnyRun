using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioObject;
    public static AudioManager instance;

    private void Awake() {
        ManageSingleton();
    }

    void ManageSingleton() {
        if (instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayClipAtPosition(AudioClip audioClip, Vector3 position, float volume) {
        if (audioClip != null && audioObject != null) {
            AudioSource.PlayClipAtPoint(audioClip, position, volume);
            
            //spawn in gameObject
            AudioSource audioSource = Instantiate(audioObject, position, Quaternion.identity);

            //assign the audioClip
            audioSource.clip = audioClip;
            audioSource.volume = volume;

            //play sound
            audioSource.Play();

            //get length of sound clip
            float clipLength = audioSource.clip.length;

            //Destroy Audio after it's done playing
            Destroy(audioSource.gameObject, clipLength);
        }
    }

    public void PlayClip(AudioClip audioClip) {
        PlayClipAtPosition(audioClip, transform.position, 1.0f);
    }
}
