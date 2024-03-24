using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSoundEffects;
    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && hasCrashed==false)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().disableController();
            Debug.Log("Kafamı Vurdum!!");
            Invoke("reloadScene",delayTime);
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSoundEffects);

        }
    }

        void reloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
