using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LastScene : MonoBehaviour
{
    public GameObject lastScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lastScene.SetActive(true);
        }
    }

    public void GoMain()
    {
        SceneManager.LoadScene(0);
    }
}
