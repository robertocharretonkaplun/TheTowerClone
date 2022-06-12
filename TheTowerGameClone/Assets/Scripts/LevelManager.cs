using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
  public static LevelManager instance;

  public int gold;
  
  public float Damage = 1;
  public  float oldDamage;
  public float bulletDamage = 1;
  public int DamageCost = 12;

  public float SpeedValue = 1.1f;
  public int SpeedCost = 5;
  public int CriticalFactor = 12;


  public TMP_Text gold_Text;
  public TMP_Text Lives_text;
  public ProgressBar livesProgressBar;
  public TMP_Text Damage_text;
  public TMP_Text DamageCost_text;

  public TMP_Text SpeedValue_text;
  public TMP_Text SpeedCost_text;
  // Start is called before the first frame update
  void Start()
  {
    if (instance != null)
    {
      return;
    }
    else
    {
      instance = this;
    }
    Time.timeScale = 1;
    oldDamage = Damage;
  }

  // Update is called once per frame
  void Update()
  {
    Damage_text.text = Damage.ToString();
    DamageCost_text.text = DamageCost.ToString();
    
    
    SpeedValue_text.text = Turret.instance.FireRate.ToString();
    SpeedCost_text.text = SpeedCost.ToString();



    gold_Text.text = gold.ToString();
    Lives_text.text = Turret.instance.CurrentLives.ToString() + "/" + Turret.instance.lives.ToString();
    livesProgressBar.maximum = Turret.instance.lives;
    livesProgressBar.current = Turret.instance.CurrentLives;

    
  }

  public void CalculateCriticalFactor()
  {
    float damageRate = Random.Range(1f, 3.5f);

    int criticalFactor = Random.Range(0, 100);
    if (criticalFactor < CriticalFactor)
    {
      oldDamage = Damage;
      float criF = Random.Range(1.5f, 2.5f);
      damageRate = criF;
      Debug.Log("Critial Factor: " + criF);
      Damage = (bulletDamage * damageRate);
    }

  }

  
}
