using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandle : MonoBehaviour
{
    [SerializeField] float delay = 2.0f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip succesSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartFinishSequence();
                break;
            case "Fuel":
                break;
            default:
                StartCrashSequence();
                break;
        }

        
    }

    void ReloadLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }

        void NextLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;
            if(nextScene == SceneManager.sceneCountInBuildSettings){
                nextScene = 0;
            }
            SceneManager.LoadScene(nextScene);
            
        }
        void StartCrashSequence()
        {
            audioSource.PlayOneShot(crashSound);
            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", delay);
        }

        private void StartFinishSequence()
        {
            audioSource.PlayOneShot(succesSound);
            GetComponent<Movement>().enabled = false;
            Invoke("NextLevel", delay);
        }
}
