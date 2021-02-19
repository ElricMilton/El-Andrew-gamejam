using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildOnCollision : MonoBehaviour
{
    SphereCollider col;
    [SerializeField] float sizeIncrease = 0.1f;
    [SerializeField] int goal = 5;
    [SerializeField] GameObject winScreen;
    int numberCollected = 0;

    void Start()
    {
        col = gameObject.GetComponent<SphereCollider>();
    }


    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collectible"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;
            GameObject ob = collision.gameObject;
            ob.transform.parent = gameObject.transform;
            ob.transform.position = pos;
            ob.GetComponent<Collider>().enabled = false;
            Grow();
        }
    }
    void Grow()
    {
        col.radius += sizeIncrease;
        numberCollected++;
        if (numberCollected == goal)
        {
            winScreen.SetActive(true);
        }
    }
}
