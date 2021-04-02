using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _virusPrefab;
    [SerializeField] private float _delay = 2f; 
    private float _createVirus = -1f;
    private bool _spwanOn = true;
    
    [SerializeField] private float _vaccinationRate = 1.5f;
    // [SerializeField] private GameObject _coronaPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSystem());
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
            Instantiate(_virusPrefab, new Vector3(Random.Range(-20.0f, 8.0f), 14f, 0), Quaternion.identity,this.transform);
            //wait for delay
            yield return new WaitForSeconds(_delay);
        }
        
    }
    
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
