using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void gameplay()
    {
        Debug.LogWarning("button has been accessed" );
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);

    }

    public void quit()
    {
        Debug.LogWarning("Application quited" );
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
