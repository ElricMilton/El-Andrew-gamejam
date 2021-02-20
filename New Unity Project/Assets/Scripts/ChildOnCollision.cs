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
    Transform modelTr;
    Vector3 scaleIncrease;
    int amountCollected = 0;


    void Start()
    {
        col = gameObject.GetComponent<SphereCollider>();
        modelTr = playerModel.transform;
        scaleIncrease = new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);

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
    }
    void CompleteLvlTwo()
    {
        print("lvl TWO completed!");
    }
    void CompleteLvlThree()
    {
        print("lvl THREE completed!");
        winScreen.SetActive(true);
    }
}
