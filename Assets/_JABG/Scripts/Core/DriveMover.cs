using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveMover : Mover
{
    private void Update() {
        if (currentDirection.x != 0)
            transform.Rotate(0, 0, -currentDirection.x * turnSpeed * Time.deltaTime);
    }

    private void FixedUpdate() {
        if (currentDirection.y != 0) {
            currentSpeed = Mathf.Clamp(currentSpeed + currentDirection.y * (aceleration / 20) * Time.fixedDeltaTime, 0, maxMoveSpeed);
        }
        rb.MovePosition(transform.position + transform.right * currentSpeed * Time.fixedDeltaTime);
    }
}
