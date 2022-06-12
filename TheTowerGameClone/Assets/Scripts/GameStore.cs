using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStore : MonoBehaviour
{
  public static GameStore instance;
  // View Distance
  public Transform ViewDistance;
  public TMP_Text ViewDistanceValue_text;
  public TMP_Text ViewDistanceCost_text;
  private float ViewDistanceValue;
  private int ViewDistanceCost = 10;


  public TMP_Text CriticalFactorValue_text;
  public TMP_Text CriticalFactorCost_text;
  private int CriticalFactorCost = 8;

  public TMP_Text TurretCost_text;
  public bool CanPlaceTurret = false;
  private int TurretAmount;
  private int TurretCost = 15;

  private void Awake()
  {
    if (instance != null)
    {
      return;
    }
    else
    {
      instance = this;
    }
  }

  // Start is called before the first frame update
  void Start()
  {
    ViewDistanceValue = Turret.instance.ViewDistance;
    ViewDistanceValue_text.text = ViewDistanceValue.ToString();
    ViewDistanceCost_text.text = ViewDistanceCost.ToString();
    // Update Critical Factor text ref
    CriticalFactorValue_text.text = LevelManager.instance.bulletDamage.ToString();
    TurretCost_text.text = TurretCost.ToString();
    CriticalFactorCost_text.text = CriticalFactorCost.ToString();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void BuyMoreDamage()
  {

    if (LevelManager.instance.gold >= LevelManager.instance.DamageCost)
    {

      LevelManager.instance.gold -= LevelManager.instance.DamageCost;
      LevelManager.instance.Damage += .5f;
      LevelManager.instance.DamageCost += 2;
      
      LevelManager.instance.oldDamage = LevelManager.instance.Damage;
    }
    else
    {
      Debug.Log("You dont have enough money.");
    }
  }

  public void BuyMoreSpeed()
  {
    if (LevelManager.instance.gold >= LevelManager.instance.SpeedCost)
    {
      LevelManager.instance.gold -= LevelManager.instance.SpeedCost;
      Turret.instance.FireRate += .3f;
      LevelManager.instance.SpeedCost += 3;
    }
    else
    {
      Debug.Log("You dont have enough money.");
    }
  }

  public void BuyMoreDistance()
  {
    if (LevelManager.instance.gold >= ViewDistanceCost)
    {
      LevelManager.instance.oldDamage = LevelManager.instance.Damage;
      LevelManager.instance.gold -= ViewDistanceCost;
      Turret.instance.ViewDistance += .05f;
      ViewDistance.localScale += new Vector3(.15f, .15f, 0);
      ViewDistanceCost += 2;

      ViewDistanceValue = Turret.instance.ViewDistance;
      // Update text ref
      ViewDistanceValue_text.text = ViewDistanceValue.ToString();
      ViewDistanceCost_text.text = ViewDistanceCost.ToString();
    }
    else
    {
      Debug.Log("You dont have enough money.");
    }
  }
  public void BuyMoreCriticalFactor()
  {
    if (LevelManager.instance.gold >= CriticalFactorCost)
    {
      LevelManager.instance.gold -= CriticalFactorCost;

      LevelManager.instance.bulletDamage += 1.5f;

      CriticalFactorCost += 4;

      // Update text ref
      CriticalFactorValue_text.text = LevelManager.instance.bulletDamage.ToString();
      CriticalFactorCost_text.text =  CriticalFactorCost.ToString();
    }
    else
    {
      Debug.Log("You dont have enough money.");
    }
  }

  public void BuyNewTurret()
  {
    if (LevelManager.instance.gold >= TurretCost)
    {
      LevelManager.instance.gold -= TurretCost;
      CanPlaceTurret = true;
      TurretCost += 5;
      TurretCost_text.text = TurretCost.ToString();
    }
    else
    {
      Debug.Log("You dont have enough money.");
    }
  }

}
