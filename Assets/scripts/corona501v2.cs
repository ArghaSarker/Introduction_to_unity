using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corona501v2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _evilVaccinePrefab; 
    [SerializeField]
    private float _alienSpeed = 10f;
    [SerializeField]
    private float _canInfect = -1f;
    [SerializeField]
    private float _infectionRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime*_alienSpeed, Space.Self);
        infect();
    }
    
    void infect()
    {
        if (Time.time > _canInfect)
        {
            Debug.Log("space pressed!");
            Debug.LogWarning("vaccine has been created!");
            _canInfect = Time.time + _infectionRate;
            
                Instantiate(_evilVaccinePrefab, transform.position + new Vector3(0,3.5f,0), Quaternion.identity);  
            
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
