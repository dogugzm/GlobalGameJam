using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartGame : MonoBehaviour
{
    public GameObject Main;
    public GameObject Credits;


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

        Main.SetActive(false);
        Credits.SetActive(true);
        
    }

    public void BackMenu()
    {
        Main.SetActive(true);
        Credits.SetActive(false);
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
