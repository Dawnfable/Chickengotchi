using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 10f;
  Vector2 targetPosition;
  bool isMoving;
  private void Update()
  {
    if (Input.GetMouseButton(0))
    {
      SetTargetPosition();
    }

    if (isMoving)
    {
      Move();
    }
  }

  void SetTargetPosition()
  {
    targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    isMoving = true;
  }

  void Move()
  {
    float step = speed * Time.deltaTime;
    transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

    if ((Vector2)transform.position == targetPosition)
    {
      isMoving = false;
    }
  }
}
