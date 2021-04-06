using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private GameObject _vaccinePrefab;
    [SerializeField] private GameObject _coronaPrefab;
    
    // ---------------   for uv light  -------------- 
    [SerializeField] private GameObject _uvLight;
    //[SerializeField] 
    private bool _useUvlight = false;
    [SerializeField] private float _uvraytime = 5f;
    
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
        _useUvlight = false;
        
    
    // geting back to origin

    transform.position = new Vector3(0f, 0f, 0f);
    

    }

    // Update is called once per frame
    void Update()
    {
        playerMovment();
        vacciate();
        

    }

    void vacciate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canVaccinate)
        {
            Debug.Log("space pressed!");
            Debug.LogWarning("vaccine has been created!");
            _canVaccinate = Time.time + _vaccinationRate;
            if (!_useUvlight)
                Instantiate(_vaccinePrefab, transform.position + new Vector3(0,2.3f,0), Quaternion.identity);
            else
            {
                Instantiate(_uvLight, transform.position + new Vector3(0,3.5f,0), Quaternion.identity);  
            }
        }
    }

    
    public void damage()
    {
        // changing the color of the mat with every hit
        // _colorChannel = _colorChannel - 0.5f;
        // _mpb.SetColor("_Color",new Color(_colorChannel,0,_colorChannel,1.0f));
        // this.GetComponent<Renderer>().SetPropertyBlock(_mpb);
        
        
        
        // destroying the object if it doesnt have any life left.
        _life = _life - 1f;
        
        if (_life == 0)
        {
            Destroy(this.gameObject);
            // having null reference exception here  !!! ERROR !!!! 
            _spawnManager.GetComponent<SpawnManager>().playerDeathe();
        }
        
             
        

        
    }

    public void playerMovment()
    {
        
                        //---------- now trying to rotate --------------
        // // Smoothly tilts a transform towards a target rotation.
        // float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        // float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        //
        // // Rotate the cube by converting the angles into a quaternion.
        // Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        //
        // // Dampen towards the target rotation
        // transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        
                            // ---------- rotation code ended --------
                            
        // getting the input axis from project manager(unity) > input

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // making player rotate while moving 
         transform.GetChild(0).Rotate(new Vector3(0f, -(horizontalInput * Time.deltaTime * _speed*1.5f), 0f),Space.World);

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
    
    
        // ------------ this portion is for uvray collection ------------
    public void enableUvray()
    {
        Debug.LogWarning("uv ray enabler accessed");
        _useUvlight = true;
        StartCoroutine(disableUvray());

    }

    IEnumerator disableUvray()
    {
        yield return new WaitForSeconds(_uvraytime);
        _useUvlight = false; 
    }
}
