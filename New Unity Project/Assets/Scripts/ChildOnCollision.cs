using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Animations;
using UnityEngine;

public class ChildOnCollision : MonoBehaviour
{
    SphereCollider col;
    [SerializeField] float sizeIncrease = 0.1f;
    [SerializeField] float colliderIncrease = 0.05f;
    [Tooltip("How much the players mass increases when an object is collected")]
    [SerializeField] float massIncrease = 1;
    [Tooltip("How much to increase the force multiplier by when an object is collected")]
    [SerializeField] float forceIncrease = 1;
    [SerializeField] int lvlOneGoal;
    [SerializeField] int lvlTwoGoal;
    [SerializeField] int lvlThreeGoal;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject playerModel;
    [SerializeField] GameObject lvlOneWall;
    [SerializeField] GameObject lvlTwoWall;
    [SerializeField] GameObject lvlThreeWall;
    [SerializeField] GameObject finishingLine;
    [SerializeField] GameObject endScreen;
    Transform modelTr;
    Vector3 scaleIncrease;
    int amountCollected = 0;
    Rigidbody rb;
    Controller controllerScript;


    void Start()
    {
        col = gameObject.GetComponent<SphereCollider>();
        modelTr = playerModel.transform;
        scaleIncrease = new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
        rb = gameObject.GetComponent<Rigidbody>();
        controllerScript = gameObject.GetComponent<Controller>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collectible"))
        {
            collision.rigidbody.mass = 0;

            amountCollected++;
            Grow();
            CheckAmount();
        }
        if (collision.gameObject == finishingLine)
        {
            finishingLine.SetActive(false);
            winScreen.SetActive(true);
            StartCoroutine(WaitForSec());

        }
    }


    void Grow()
    {
        col.radius += colliderIncrease;
        modelTr.localScale += scaleIncrease;
        rb.mass += massIncrease;
        controllerScript.forceMultiplyer += forceIncrease;
    }

    void CheckAmount()
    {
        if (amountCollected == lvlOneGoal)
        {
            CompleteLvlOne();
        }
        else if (amountCollected == lvlTwoGoal)
        {
            CompleteLvlTwo();
        }
        else if (amountCollected == lvlThreeGoal)
        {
            CompleteLvlThree();
        }
    }

    void CompleteLvlOne()
    {
        print("lvl ONE completed!");
        lvlOneWall.SetActive(false);
    }
    void CompleteLvlTwo()
    {
        print("lvl TWO completed!");
        lvlTwoWall.SetActive(false);
    }
    void CompleteLvlThree()
    {
        print("lvl THREE completed!");
        lvlThreeWall.SetActive(false);
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        endScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
