using UnityEngine;


//A class to allow the easy modification of all variables


public static class Tags
{

    public static string player = "Player";
    public static string enemy = "Enemy";


    public static string world = "World";









}


//Enums for states

public enum SpriteState { Active, Inactive };

public enum SpriteType { Safe, Danger, Player };

public enum SpriteDirection { Left, Right, Player };