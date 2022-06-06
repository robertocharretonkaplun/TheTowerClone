using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turret : MonoBehaviour
{
  public static Turret instance;
  public float Range;
  public int CurrentLives = 5;
  public int lives = 5;
  Transform Target;
  bool Detected = false;
  Vector2 Direction;
  public GameObject Gun;
  public GameObject bullet;
  public float FireRate;
  float nextTimeToFire = 0;
  public Transform Shootpoint;
  public float Force;
  public float speed = 1.5f;
  public bool isChildTurret = false;
  public Vector3 shootOffset = Vector3.forward;
  public GameObject EnemyContainer;
  Vector3 closeEnemyRef;

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
    InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
  }
  // Update is called once per frame
  void Update()
  {

    if (CurrentLives <= 0)
    {
      CurrentLives = 0;
      Destroy(gameObject);
      if (!isChildTurret)
      {
        Time.timeScale = 0;
        SceneManagement.instance.ChangeToMainMenuScene();
        return;
      }
    }


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
    LevelManager.instance.CalculateCriticalFactor();
    GameObject BulletIns = Instantiate(bullet, Shootpoint.position , Quaternion.identity);
    BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force * speed);
    LevelManager.instance.Damage = LevelManager.instance.oldDamage;
  }
  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(transform.position, Range);
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, .25f);
    Gizmos.color = Color.cyan;
    Gizmos.DrawLine(transform.position, closeEnemyRef);
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

      if (isChildTurret && distance <= 0.35f)
      {
        Destroy(gameObject);
      }
      // Check what enemy is closer and set it as the principal enemu
      if (distance < shortDistance)
      {
        shortDistance = distance;
        closeEnemy = enemy;
        closeEnemyRef = enemy.transform.position;
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