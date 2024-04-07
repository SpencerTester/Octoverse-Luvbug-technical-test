using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "LuvBug Technical Assesment/Sprite Statistics")]

public class SpriteStatistics : ScriptableObject
{
    [Header("General")]
    public SpriteState  _state;
    public SpriteType _type;



    [Header("Movement")]
    public float _speed;
    



}
