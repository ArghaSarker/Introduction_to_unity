using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private GameObject _bubblePower;

    private float _bubblerate = 20f;
    // [SerializeField] private GameObject _coronaPrefab;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSystem());
        StartCoroutine(SpawnUvray());
        StartCoroutine(SpawnDoughnut());
        StartCoroutine(SpawnBubble());
        StartCoroutine(YourName());

    }

    public float timeRemaining = 3f;

    // Update is called once per frame
    void Update()
    {

    }

    // creating a method to stop the spawning process
    public void playerDeathe()
    {
        //FindObjectOfType<audiomanager>().play("player destroyed");
        
        FindObjectOfType<audiomanager>().play("player death");
        _spwanOn = false;
        
        
        SceneManager.LoadScene(0);
        


    }
    IEnumerator YourName()
    {
        //you can replace 3 with the amount of seconds to wait
        //for a time like 1.2 seconds, use 1.2f (to show it's a float)
        yield return new WaitForSeconds(3);
        Debug.Log("Finished waiting!");
    }

    IEnumerator SpawnSystem()
    {
        // as long as the game is running
        while (_spwanOn)
        {

            //virus();
            // instantiate the viruses
            Instantiate(_virusPrefabs[UnityEngine.Random.Range(0, _virusPrefabs.Count)],
                new Vector3(Random.Range(-24.0f, -1.52f), 32f, 0), Quaternion.identity, this.transform);
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
            Instantiate(_uvrayprefab, new Vector3(Random.Range(-24.0f, -1.52f), 32f, 0), Quaternion.identity);
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
            Instantiate(_doughnut, new Vector3(Random.Range(-24.0f, -1.52f), 32f, 0), Quaternion.identity);
            Debug.LogWarning("Doughnut has been created");
            //wait for delay
            yield return new WaitForSeconds(_doughnutrate);
        }

    }


    IEnumerator SpawnBubble()
    {
        // as long as the game is running
        while (_spwanOn)
        {


            // instantiate the uvray
            Instantiate(_bubblePower, new Vector3(Random.Range(-24.0f, -1.52f), 32f, 0), Quaternion.identity);
            Debug.LogWarning("Doughnut has been created");
            //wait for delay
            yield return new WaitForSeconds(_bubblerate);
        }

    }
}



