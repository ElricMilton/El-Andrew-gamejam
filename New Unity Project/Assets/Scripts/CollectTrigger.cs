using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTrigger : MonoBehaviour
{
    public AnimatorOverrideController animatorOverride;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            anim.runtimeAnimatorController = animatorOverride;

        }
    }
}
