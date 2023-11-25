using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMover : Mover
{

    private void Update() {
        acelerate();
        Rotate();
    }

    // Start is called before the first frame update
    private void FixedUpdate() {
        Vector2 destiny = currentDirection * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + new Vector3(destiny.x,destiny.y,transform.position.z));
    }

    private void acelerate() {
        if (currentDirection != Vector2.zero && currentSpeed <= maxMoveSpeed) {
            currentSpeed += (aceleration / 100) * Time.deltaTime;
        } else if (currentDirection == Vector2.zero && currentSpeed > 0) {
            currentSpeed -= aceleration * Time.deltaTime;
        }
    }

    private void Rotate() {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, currentDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        transform.rotation =rotation;
    }
}
