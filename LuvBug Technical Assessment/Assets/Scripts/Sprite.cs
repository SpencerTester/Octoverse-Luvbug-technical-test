using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{

    [Header ("Statistics")]
    public SpriteStatistics _stats;



    [Header("States")]
    public float _currentSpeed;
    public SpriteDirection _currentMoveType;
    public bool _isAlive = true;




    [Header("Debug")]
    public Vector2 _movement;


    //A method for when we start
    public virtual void Init()
    {

        _currentSpeed = _stats._speed;


    }



    //A method to update once every X seconds
    public virtual void Tick()
    {


        if(!_isAlive)
        {
            Destroy(this);
            return;

        }    

        HandleMovement();


    }


    //A method to handle our movement based on our _Movement Vec2
    protected virtual void HandleMovement()
    {




        transform.Translate(_movement * _currentSpeed * Time.deltaTime);

    }


    public virtual void TakeDamage()
    {



    }

    protected virtual void HandleDeath()
    {

        _isAlive = false;

    }


    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

        
    }


}
