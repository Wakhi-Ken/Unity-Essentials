using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float rotationSpeed;
    public GameObject onCollectEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Rotate(0, rotationSpeed, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
          
        }

        //Destroy the collectabel
        Destroy(gameObject);

        //Instantiate the onCollectEffect at the position and rotation of the collectable
        Instantiate(onCollectEffect, transform.position, transform.rotation);
    }
}
