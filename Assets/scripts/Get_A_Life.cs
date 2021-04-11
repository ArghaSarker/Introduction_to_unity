using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_A_Life : MonoBehaviour
{

    [SerializeField] 
    private float _speedOfDoughnut = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down*Time.deltaTime*_speedOfDoughnut,Space.World);
        //transform.Rotate(new Vector3(0, 0.3f, 0));
        
        //-----------------------------------
        
        //transform.Translate(Vector3.down * Time.deltaTime*_coronaSpeed, Space.World);
        if (name.Contains("Doughnut"))
        {
            transform.Translate(Vector3.right * UnityEngine.Random.Range(-5f, 5f) * Time.deltaTime * _speedOfDoughnut , Space.World);
        }
        //--------------------------------
        
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {   // here I have to add life
            GameObject.FindWithTag("Player").GetComponent<Player>().damage(-1);
            FindObjectOfType<audiomanager>().play("life collecetd");
            //other.GetComponent<Player>().enableUvray();
            Debug.LogWarning("power collected");
            Destroy(this.gameObject);
        }
    }
}
