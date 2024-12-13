using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Health stats
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    public float HealthPercentage                                                           //Getter function for healthPercenate of object this script is attached to. This is another way of writing Lambda function. 
    {
        get { return _currentHealth / _maxHealth; }
    }



    //Team of object - objects can only damage (affect courage) of objects of opposing teams.
    [SerializeField]
    private int team;
    public int GetTeam => team;                                                             //Getter LAMBDA function for team of object this script is attached to 

    private void Start()
    {
        _currentHealth = _maxHealth;
    }


    public void ApplyDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth -  damage, 0, _maxHealth);              //Assign new health. Take off damage from health while clamping range between 0 and healthMax

        if(_currentHealth <= 0 && gameObject.tag == "Enemy")                                                              //perform check. Cap Health min at 0.
        {
            Destroy(gameObject);                                                            //Destroy object this script is attached to if currentHealth is below min of 0.
        }

        if (_currentHealth <= 0 && gameObject.tag == "Player")                                                              //perform check. Cap Health min at 0.
        {
            GameManager.GameOver();                                                         //Call GameOver
        }


    }



}
