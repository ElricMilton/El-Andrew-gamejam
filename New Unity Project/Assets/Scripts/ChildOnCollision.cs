using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildOnCollision : MonoBehaviour
{
    SphereCollider col;
    [SerializeField] float sizeIncrease = 0.2f;

    void Start()
    {
        col = gameObject.GetComponent<SphereCollider>();
    }


    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collectable"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;
            GameObject ob = collision.gameObject;
            ob.transform.parent = gameObject.transform;
            ob.transform.position = pos;
            ob.GetComponent<Collider>().enabled = false;
            col.radius += sizeIncrease;
            //collision.gameObject.transform.localPosition
        }
    }
}
