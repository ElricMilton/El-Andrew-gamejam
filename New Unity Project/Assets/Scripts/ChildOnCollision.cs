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
    [SerializeField] int lvlOneGoal;
    [SerializeField] int lvlTwoGoal;
    [SerializeField] int lvlThreeGoal;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject playerModel;
    [SerializeField] GameObject lvlOneWall;
    [SerializeField] GameObject lvlTwoWall;
    [SerializeField] GameObject lvlThreeWall;
    [SerializeField] GameObject finishingLine;
    Transform modelTr;
    Vector3 scaleIncrease;
    int amountCollected = 0;
    Rigidbody rb;


    void Start()
    {
        col = gameObject.GetComponent<SphereCollider>();
        modelTr = playerModel.transform;
        scaleIncrease = new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
        rb = gameObject.GetComponent<Rigidbody>();

    }


    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collectible"))
        {
            amountCollected++;
            Grow();
            CheckAmount();
        }
        if (collision.gameObject == finishingLine)
        {
            finishingLine.SetActive(false);
            winScreen.SetActive(true);
        }
    }
    void Grow()
    {
        col.radius += colliderIncrease;
        modelTr.localScale += scaleIncrease;

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
}
