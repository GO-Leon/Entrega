using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyData", menuName = "Enemy Data")]

public class EnemyData : ScriptableObject

{
    public float distanceRay;
    public int coolDown;
    public float timeShoot;
    public bool canshoot;

}
