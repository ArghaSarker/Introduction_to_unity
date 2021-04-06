using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class corona : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    // speed initialized
    [SerializeField]
    private float _coronaSpeed = 7f;
    [SerializeField]
    private float _horizontalSpeed = 10f;

    [SerializeField] public Player _player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        transform.Translate(Vector3.down * Time.deltaTime*_coronaSpeed, Space.World);
        if (name.Contains("B117"))
        {
            transform.Translate(Vector3.right * UnityEngine.Random.Range(-3f, 3f) * Time.deltaTime * _horizontalSpeed , Space.World);
        }
        
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
        // 1.  now detect who hits whom. 
        if (other.CompareTag("Player"))
        {
            // 2. if corona hits player --> player dead or damaged
            
            other.GetComponent<Player>().damage(); 
            Debug.LogWarning("this player collided with virus");
            Destroy(this.gameObject);
        }
        
        else if (other.CompareTag("vaccine"))
        {
            // detect the uv light 
            if ( other.name.Contains("UVLight"))
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

        }
    }
}
