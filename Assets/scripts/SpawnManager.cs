using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _virusPrefab;
    [SerializeField] private List<GameObject> _virusPrefabs; 
    [SerializeField] private float _delay = 1.2f; 
    private float _createVirus = -1f;
    private bool _spwanOn = true;
    
    // ------- for uvray ---------
    [SerializeField] private GameObject _uvrayprefab;
    [SerializeField] private GameObject _doughnut;
    [SerializeField] private float _doughnutrate = 15f;
    [SerializeField] private float _uvrayrate = 10f;
    
    
    [SerializeField] private float _vaccinationRate = 1.5f;
    // [SerializeField] private GameObject _coronaPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSystem());
        StartCoroutine(SpawnUvray());
        StartCoroutine(SpawnDoughnut());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // creating a method to stop the spawning process
    public void playerDeathe()
    {
        _spwanOn = false; 
    }

    IEnumerator SpawnSystem()
    {
        // as long as the game is running
        while (_spwanOn)
        {
            
            //virus();
            // instantiate the viruses
            Instantiate(_virusPrefabs[UnityEngine.Random.Range(0,_virusPrefabs.Count)], new Vector3(Random.Range(-24.0f, -1.52f), 23f, 0), Quaternion.identity,this.transform);
            //wait for delay
            yield return new WaitForSeconds(_delay);
        }
        
    }
    IEnumerator SpawnUvray()
    {
        // as long as the game is running
        while (_spwanOn)
        {
            
            
            // instantiate the uvray
            Instantiate(_uvrayprefab, new Vector3(Random.Range(-24.0f, -1.52f), 23f, 0), Quaternion.identity);
            Debug.LogWarning("uv has been created");
            //wait for delay
            yield return new WaitForSeconds(_uvrayrate);
        }
        
    }
    IEnumerator SpawnDoughnut()
    {
        // as long as the game is running
        while (_spwanOn)
        {
            
            
            // instantiate the uvray
            Instantiate(_doughnut, new Vector3(Random.Range(-24.0f, -1.52f), 23f, 0), Quaternion.identity);
            Debug.LogWarning("Doughnut has been created");
            //wait for delay
            yield return new WaitForSeconds(_doughnutrate);
        }
        
    }
    
//     //------------ laser light system ---------------- 
//     
//     IEnumerator FireLaser()
//     {
//         line.enabled = true;
//         while (Input.GetButton("Fire1"))
//         {
//             Ray ray = new Ray(transform.position, transform.forward);
//             RaycastHit hit;
//  
//             line.SetPosition(0, ray.origin);
//  
//             if (Physics.Raycast(ray, out hit, 100))
//                 line.SetPosition(1, hit.point);
//             else
//                 line.SetPosition(1, ray.GetPoint(100));
//  
//             yield return null;
//         }
//  
//         line.enabled = false;
//  
//     }
// }

    
    // void virus()
    // {
    //     // we are just adding depaly in the if statement
    //     if (Time.time > _createVirus )
    //     {
    //         // for creating random axis
    //         Vector3 position = new Vector3(Random.Range(-20.0f, 8.0f), 14f,0 );
    //         Debug.Log("virus created!");
    //         
    //         // creating more delay
    //         _createVirus = Time.time + _vaccinationRate +1.0f ; 
    //         
    //         
    //         //the object is being created here
    //         Instantiate(_coronaPrefab, transform.position + position, Quaternion.identity);
    //
    //     }
    // }
}
