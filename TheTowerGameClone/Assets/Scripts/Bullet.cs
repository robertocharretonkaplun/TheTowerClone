using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class
Bullet : MonoBehaviour
{
  private Transform target;

  public float speed = 1.0f;

  public GameObject destroyEffect;
  
  // Update is called once per frame
  void
  Update()
  {
    // Check if there is a target to follow
    if (target != null)
    {
    }
    else
    {
      // If there is a target, then destroy the object
      Destroy(gameObject);
      return;
    }

    // Get the direction of the enemy target
    Vector3 direction = target.position - transform.position;
    float distance = speed * Time.deltaTime;

    // Check if the distance is valid from the direction from the target 
    // and hit the enemy target
    if (direction.magnitude <= distance)
    {
      Hit();
      return;
    }
    // Move the bullets from the initial position to the enemy target position
    transform.Translate(direction.normalized * distance, Space.World);
  }

  /*
   * brief: Method in charfe of setting a reference to the enemy target
   */
  public void
  FollowTarget(Transform _target)
  {
    target = _target;
  }

  /*
   * brief: Method in charge of destroying the enemies, updating the player points,
   * and generating and destroying the enemy dead particles.
   */
  private void
  Hit()
  {
    if (target.gameObject.tag == "Unit-Level1")
    {
      LevelManager.instance.gold += 1;
    }
    if (target.gameObject.name == "Unit-Level2")
    {
      LevelManager.instance.gold += 2;
    }
    // Remove one enemy from the enemy counter
    //LevelManager.instance.amounOfEnemies--;
    // Generate a new partecle from each enemy target that dies
    //var Particle = Instantiate(destroyEffect, transform.position, transform.rotation);
    // Destroy the enemy particles
    //Destroy(Particle, 1.5f);
    // Destroy the enemy object
    Destroy(target.gameObject);
    // Destroy the bullet object
    Destroy(gameObject);

  }
}