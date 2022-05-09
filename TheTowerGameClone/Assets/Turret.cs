using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turret : MonoBehaviour
{
  public float Range;
  Transform Target;
  bool Detected = false;
  Vector2 Direction;
  public GameObject Gun;
  public GameObject bullet;
  public float FireRate;
  float nextTimeToFire = 0;
  public Transform Shootpoint;
  public float Force;

  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
  }
  // Update is called once per frame
  void Update()
  {
    if (Target != null)
    {

      Vector2 targetPos = Target.position;
      Direction = targetPos - (Vector2)transform.position;
      RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
      if (rayInfo)
      {
        if (rayInfo.collider.gameObject.tag == "Unit")
        {
          if (Detected == false)
          {
            Detected = true;
          }
        }
        else
        {
          if (Detected == true)
          {
            Detected = false;
          }
        }
      }
      if (Detected)
      {
        //Gun.transform.up = Direction;
        if (Time.time > nextTimeToFire)
        {
          nextTimeToFire = Time.time + 1 / FireRate;
          shoot();
        }
      }
    }
  }
  void shoot()
  {
    GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
    BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
  }
  private void OnDrawGizmosSelected()
  {
    Gizmos.DrawWireSphere(transform.position, Range);
    Gizmos.DrawWireSphere(transform.position, .25f);

  }


  void
  UpdateTarget()
  {
    // Set a reference to the list of enemies in the game
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Unit");
    float shortDistance = Mathf.Infinity;
    GameObject closeEnemy = null;

    foreach (GameObject enemy in enemies)
    {
      // Get the distance from the enemy position and the turret position
      float distance = Vector3.Distance(transform.position, enemy.transform.position);
      // Check what enemy is closer and set it as the principal enemu
      if (distance < shortDistance)
      {
        shortDistance = distance;
        closeEnemy = enemy;
      }
    }
    // Check that the enemy that is closer to the turret became the main target
    if (closeEnemy != null && shortDistance <= Range)
    {
      Target = closeEnemy.transform;
    }
    else
    {
      Target = null;
    }
  }
}