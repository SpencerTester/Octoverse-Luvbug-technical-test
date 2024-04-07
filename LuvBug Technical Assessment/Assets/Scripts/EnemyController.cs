using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Inherits from sprite

public class EnemyController : Sprite
{


    public Vector2 _spawnLocation;

    //Delete if unused
    public Transform _target;


    [Header("Type")]
    protected SpriteType _type;

    //Delegate Object
    protected MovePattern _move;

    


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(_type);
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
    }


    public override void Init()
    {
        base.Init();

        //set spawn location
        _spawnLocation = transform.position;


        //Parent to enemies object for transform
        transform.parent = GameObject.Find("Enemies").transform;

        selectMovementType();
        Debug.Log(_type);
    }


    public override void Tick()
    {
        base.Tick();
    }

    protected override void HandleMovement()
    {

        //Check if move is null
        _move?.Invoke(this);

        base.HandleMovement();
    }

    void selectMovementType()
    {
        _currentSpeed = _stats._speed;

        //between -1 and 1
        int randomDirection = Random.Range(-1, 2);
        while (randomDirection == 0)
        {

            randomDirection = Random.Range(-1, 2);

        }

        //Move us based on our random direction
        _movement = Vector2.right * randomDirection;
        int randomHeight = Random.Range(0, 4);

        if (randomDirection == -1)
        {

            if (randomHeight == 0)
            {
                transform.position = GameObject.Find("SpawnR1").transform.position;
            }

            if (randomHeight == 1)
            {
                transform.position = GameObject.Find("SpawnR2").transform.position;
            }
            if (randomHeight == 2)
            {
                transform.position = GameObject.Find("SpawnR0").transform.position;
            }


        }

        else
        {
            if (randomHeight == 0)
            {
                transform.position = GameObject.Find("SpawnL1").transform.position;
            }

            if (randomHeight == 1)
            {
                transform.position = GameObject.Find("SpawnL2").transform.position;
            }
            if (randomHeight == 2)
            {
                transform.position = GameObject.Find("SpawnL0").transform.position;
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if(other.gameObject.tag == "Player")
        {

            transform.position = GameObject.Find("Culling").transform.position;

            Destroy(this);
            
        
        }


    }

    //Delegates
    public delegate void MovePattern(EnemyController ec);




}
