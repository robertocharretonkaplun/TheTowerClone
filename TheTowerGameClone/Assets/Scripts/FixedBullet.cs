using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBullet : MonoBehaviour
{

  //public float moveSpeed = 100f;
  //private Rigidbody2D rb;
  //private Vector2 movement;
  //public Transform target;
  //// Start is called before the first frame update
  //void Start()
  //{
  //  rb = this.GetComponent<Rigidbody2D>();
  //}
  //
  //public void Update()
  //{
  //  Vector3 direction = target.position - transform.position;
  //  float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
  //  //rb.rotation = angle;
  //  direction.Normalize();
  //  movement = direction;
  //
  //  // Check if the distance is valid from the direction from the target 
  //  // and hit the enemy target
  //  if (direction.magnitude <= 5)
  //  {
  //    Hit();
  //    return;
  //  }
  //
  //}
  //
  //private void FixedUpdate()
  //{
  //  moveCharacter(movement);
  //}
  //void moveCharacter(Vector2 direction)
  //{
  //  rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
  //}
  //
  //
  //private void
  //Hit()
  //{
  //  // Add 1 point to the player to be able to create more turrets
  //  //LevelManager.instance.points += 1;
  //  // Remove one enemy from the enemy counter
  //  //LevelManager.instance.amounOfEnemies--;
  //  // Generate a new partecle from each enemy target that dies
  //  //var Particle = Instantiate(destroyEffect, transform.position, transform.rotation);
  //  // Destroy the enemy particles
  //  //Destroy(Particle, 1.5f);
  //  // Destroy the enemy object
  //  Destroy(target.gameObject);
  //  // Destroy the bullet object
  //  Destroy(gameObject);
  //
  //}

  private void Update()
  {
    Destroy(gameObject, 2.5f);
  }


  private void OnCollisionEnter2D(Collision2D collision)
  {
    collision.gameObject.GetComponent<Unit>().health -= LevelManager.instance.Damage;

    if (collision.gameObject.GetComponent<Unit>().health < 1 && collision.gameObject.GetComponent<Unit>().Name == "Unit-Level1")
    {
      LevelManager.instance.gold += 1;
    }
    if (collision.gameObject.GetComponent<Unit>().health < 1 && collision.gameObject.GetComponent<Unit>().Name == "Unit-Level2")
    {
      LevelManager.instance.gold += 2;
    }
    if (collision.gameObject.GetComponent<Unit>().health < 1 && collision.gameObject.GetComponent<Unit>().Name == "Unit-Level3")
    {
      LevelManager.instance.gold += 4;
    }
    if (collision.gameObject.GetComponent<Unit>().health < 1)
    {
      Destroy(collision.gameObject);
    }
    Destroy(gameObject);
  }
}
