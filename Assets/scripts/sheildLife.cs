using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheildLife : MonoBehaviour
{
    // Start is called before the first frame update
    public float liveTime = 5f;

    void Update()
    {




    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
        // 1.  now detect who hits whom. 
        if (other.CompareTag("Player"))
        {
            // 2. if corona hits player --> player dead or damaged

           // other.GetComponent<Player>().damage(1);
            Debug.LogWarning("this player collided with virus");
            Destroy(this.gameObject);
        }

        else if (other.CompareTag("vaccine"))
        {
            // detect the uv light 
            if (other.name.Contains("UVLight"))
            {

                // destroying only the uv light
                Destroy(this.gameObject);
            }
            else
            {
                // 3. if vaccine hits corona--> destroy both
                // other.GetComponent<vaccine>().Point();
                Debug.LogWarning("vaccine collided virus destroy both");
                // destroying bonth
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }

            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(5);

        }

    }
}