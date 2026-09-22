using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAnimationConfiguration", menuName = "Scriptable Objects/PlayerAnimationConfiguration")]
public class PlayerAnimationConfiguration : ScriptableObject
{
    public string idleAnimationName = "Idle";
    public string runAnimationName = "Run";
    public string jumpAnimationName = "Jump";
    public string fallAnimationName = "Fall";
    public string landAnimationName = "Land";
    public string rollAnimationName = "Roll";
    public string danceAnimationName = "Dance";
}
