using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game Configurations")]
public class GameConfig : ScriptableObject
{
  public float Health = 10;
  public float Rounds = 10;
  public float Damage = 10;
  public float Speed = 10;
  public float CriticOportunity = 10;
  public float Distance = 10;
  public float DamageFromDistance = 10;
  public float CriticFactor = 10;
}
