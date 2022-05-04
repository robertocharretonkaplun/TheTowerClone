using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
  public int health = 200;
  public float moveSpeed = 100f;
  private Rigidbody2D rb;
  private Vector2 movement;
  public Transform target;
  // Start is called before the first frame update
  void Start()
  {
    rb = this.GetComponent<Rigidbody2D>();
  }

  public void Update()
  {
    Vector3 direction = target.position - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //rb.rotation = angle;
    direction.Normalize();
    movement = direction;
  }

  private void FixedUpdate()
  {
    moveCharacter(movement);
  }
  void moveCharacter(Vector2 direction)
  {
    rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
  }
}
