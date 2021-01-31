using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private GameObject deathBlack;
    


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DeathProcess();
        }
    }

    public void  Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void DeathProcess()
    {

        deathBlack.SetActive(true);
        Invoke("Restart",3f);
    }
}
