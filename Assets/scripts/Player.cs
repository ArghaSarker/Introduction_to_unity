using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private GameObject _vaccinePrefab;
    [SerializeField] private GameObject _coronaPrefab;
    [SerializeField] private float _life = 5f;
    [SerializeField] private float _vaccinationRate = 1f;
    [SerializeField] public float countPoint = 1f;
    

    [SerializeField] private GameObject _spawnManager;
    // private corona _corona;

    private float _canVaccinate = -1f; 
    // private float _createVirus = -1f;
    private MaterialPropertyBlock _mpb;
    private float _colorChannel = 1f; 
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // setting up new material property block to reuse it. 
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();
            this.GetComponent<Renderer>().GetPropertyBlock(_mpb);
        }
    
    // geting back to origin

    transform.position = new Vector3(10f, 0f, 0f);
    

    }

    // Update is called once per frame
    void Update()
    {
        playerMovment();
        vacciate();
        // virus();

    }

    void vacciate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canVaccinate )
        {
            Debug.Log("space pressed!");
            Debug.LogWarning("vaccine has been created!");
            _canVaccinate = Time.time + _vaccinationRate; 

            Instantiate(_vaccinePrefab, transform.position + new Vector3(0,2.3f,0), Quaternion.identity);

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

    public void damage()
    {
        // changing the color of the mat with every hit
        _colorChannel = _colorChannel - 0.5f;
        _mpb.SetColor("_Color",new Color(_colorChannel,0,_colorChannel,1.0f));
        this.GetComponent<Renderer>().SetPropertyBlock(_mpb);
        
        
        
        // destroying the object if it doesnt have any life left.
        _life = _life - 1f;
        
        if (_life == 0)
        {
            Destroy(this.gameObject);
            // having null reference exception here  !!! ERROR !!!! 
            _spawnManager.GetComponent<SpawnManager>().playerDeathe();
        }
        
             
        

        
    }

    // public void Point()
    // {
    //     Debug.LogWarning("method accessed");
    //     countPoint = countPoint + 1; 
    // }




    // Vector3 position = new Vector3(Random.Range(-20.0f, 8.0f), 14f,0 );
        // Instantiate(_coronaPrefab,  position, Quaternion.identity);

    

    void playerMovment()
    {
        // getting the input axis from project manager(unity) > input

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //  creating the movements from player
        Vector3 playerTranslate = new Vector3(1f * Time.deltaTime * _speed * horizontalInput,
            1f * Time.deltaTime * _speed * verticalInput, 0f);

        transform.Translate(playerTranslate);
        
        
        
        
        if (transform.position.x > 8f)
        {
            transform.position = new Vector3(8f,transform.position.y,0f);
        }
        else if(transform.position.x < -20f)
        { 
            transform.position = new Vector3(-20f,transform.position.y,0f);
        }
        
        
        if(transform.position.y< -7f)
        {
            transform.position = new Vector3(transform.position.x,-7f,0f);
        }
        else if (transform.position.y > 13f)
        {
            transform.position = new Vector3(transform.position.x, 13f, 0f);
        }
        
    }
}
