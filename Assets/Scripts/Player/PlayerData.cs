using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Player Data")]
public class PlayerData : ScriptableObject
{
    public int Maxhp = 100;
    public float Movespeed = 5f;
    public int Atk = 10;
    public float Ats = 10f;
    public int Reducation = 0;
    public float Firerate = 0f;
    public int Change = 3;
}