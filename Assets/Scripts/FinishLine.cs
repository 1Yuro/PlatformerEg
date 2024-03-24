using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Player")
        {
            finishEffect.Play();
            Debug.Log("Bitti!!");
            Invoke("reloadScene",delayTime);
            GetComponent<AudioSource>().Play();

        }

    }

    void reloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
