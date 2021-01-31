using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    
    GameObject player;
    [SerializeField] private GameObject deathBlack;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("newPlayer");
        
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
        //SceneManager.LoadScene("SampleScene");
        player.GetComponent<Transform>().position = player.GetComponent<PlayerController>().spawnObject.transform.position;
    }

    public void DeathProcess()
    {

        deathBlack.SetActive(true);
        Invoke("Restart",3f);
    }
}
