using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "playerData",menuName="Player Data")]

public class PlayerData : ScriptableObject

{
    public float speedPlayer;
    public float jumpForce;
    public string playerName;

}
