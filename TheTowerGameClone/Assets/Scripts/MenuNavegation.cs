using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavegation : MonoBehaviour
{
  public GameObject UpgradeAttack;
  public GameObject UpgradeHealth;
  public GameObject TurretsMenu;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }


  public void ActivateUpgradeAttackMenu()
  {
    UpgradeAttack.SetActive(true);
    UpgradeHealth.SetActive(false);
    TurretsMenu.SetActive(false);
  }
  
  public void ActivateUpgradeHealthMenu()
  {
    UpgradeAttack.SetActive(false);
    UpgradeHealth.SetActive(true);
    TurretsMenu.SetActive(false);
  }
  public void ActivateTurretMenu()
  {
    UpgradeAttack.SetActive(false);
    UpgradeHealth.SetActive(false);
    TurretsMenu.SetActive(true);
  }
}
