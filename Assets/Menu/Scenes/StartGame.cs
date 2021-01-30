using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartGame : MonoBehaviour
{

    Animator animator;
    public AudioSource blip;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScene()
    {
        
        SceneManager.LoadScene("SampleScene");
    }

    public void StartCredits()
    {
        

        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        

        Application.Quit();
    }

    public void PlaySound()
    {
        blip.Play();
    }

}
