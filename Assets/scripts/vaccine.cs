using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaccine : MonoBehaviour
{
    // Start is called before the first frame update
    // vaccine speed
    [SerializeField] 
    private float _speedVaccine = 22f;

    [SerializeField] 
    private float _rotationSpeed = 45f;

    [SerializeField] public float point = 0f;

    private Player _player;

    
        
        
    void Start()
    {
        //transform.position = new Vector3(10f, 0f, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,_rotationSpeed * Time.deltaTime , 0f),Space.Self);
        if (CompareTag("vaccine"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * _speedVaccine, Space.World);


            if (transform.position.y > 25f)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * _speedVaccine, Space.World);

            if (transform.position.y < -25f)
            {
                Destroy(this.gameObject);
            }
        }

    }
   
    public void Point()
    {
        Debug.LogWarning("method accessed");
        point = point + 1; 
    }
}
