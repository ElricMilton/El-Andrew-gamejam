using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectTrigger : MonoBehaviour
{
    public AnimatorOverrideController animatorOverride;
    GameObject particleOb;
    ParticleSystem particle;
    Animator anim;
    Rigidbody rb;
    Collider col;
    Transform partPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<Collider>();
        particleOb = GameObject.FindGameObjectWithTag("Particle");
        partPos = particleOb.transform;
        particle = particleOb.GetComponent<ParticleSystem>();
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
            partPos.position = pos;
            particle.Play();
        }
    }
}
