using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{

    public GameObject book;
    public GameObject textUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && book.activeSelf == false)
        {
            textUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                book.SetActive(true);
            }
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textUI.SetActive(false);
            book.SetActive(false);
        }
        
    }
}
