using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CollectTrigger : MonoBehaviour
{
    public AnimatorOverrideController animatorOverride;
    Animator anim;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            anim.runtimeAnimatorController = animatorOverride;
            rb.isKinematic = true;
        }
    }
}
