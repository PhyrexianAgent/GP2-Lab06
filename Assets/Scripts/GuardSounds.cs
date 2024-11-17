using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GuardSounds : MonoBehaviour
{
    
    [SerializeField] private AudioClip stepSound;

    private AudioSource audio;
    void Awake(){
        audio = GetComponent<AudioSource>();
    }
    public void PlayStep(){
        audio.PlayOneShot(stepSound);
    }
}
