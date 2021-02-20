using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CollectTrigger : MonoBehaviour
{
    public AnimatorOverrideController animatorOverride;
    Animator anim;
    Rigidbody rb;
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            anim.runtimeAnimatorController = animatorOverride;
            rb.isKinematic = true;
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;
            GameObject ob = collision.gameObject;
            gameObject.transform.parent = ob.transform;
            gameObject.transform.position = pos;
            col.enabled = false;
        }
    }
}
