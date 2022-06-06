using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
  public GameObject TurretChild;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.Escape))
    {

    }
    if (Input.GetMouseButtonDown(0) && GameStore.instance.CanPlaceTurret)
    {
      Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      var turret = Instantiate(TurretChild, (Vector2)pos, Quaternion.identity);
      GameStore.instance.CanPlaceTurret = false;
    }
  }
}
