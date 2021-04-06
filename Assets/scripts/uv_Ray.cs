using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uv_Ray : MonoBehaviour
{
    
    [SerializeField] 
    private float _speedOfUV = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down*Time.deltaTime*_speedOfUV,Space.World);
        //transform.Rotate(new Vector3(0, 0.3f, 0));
        
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().enableUvray();
            Debug.LogWarning("power collected");
            Destroy(this.gameObject);
        }
    }
}
