using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.iOS;

public class CatMovement : MonoBehaviour
{
    //MOVEMENT ADJUSTABLE ATTRIBUTES
    [SerializeField] private float catSpeed = 30.0f;

    public List<Color> colors;

    private Rigidbody _rb;

    private bool isFirstCollision;

    

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();     //assign the RigidBody element of the object this script is attached to variable _rb
        isFirstCollision = false;
        AddColorsToList();
        
    }

    private void Start()
    {
        _rb.AddForce(transform.forward *  catSpeed, ForceMode.Impulse);
    }

    private int GetRandomInt (int min, int max)
    {
        int result = Random.Range(min, max);
        Debug.Log("colours rand : " + result);
        return result;
    }

    private void AddColorsToList()
    {
        colors.Add(Color.white);
        colors.Add(Color.yellow);
        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.blue);
        colors.Add(Color.cyan);
        colors.Add(Color.magenta);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && !isFirstCollision && collision.gameObject.tag == "Wall")
        {
            isFirstCollision = true;
            int colorIndex = GetRandomInt(0, colors.Count);
            collision.gameObject.GetComponent<MeshRenderer>().material.color = colors[colorIndex];
        }

        if(collision != null && collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        
        
        Destroy(gameObject, 2);
        
    }
}
