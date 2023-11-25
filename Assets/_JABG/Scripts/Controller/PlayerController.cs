using Fabio.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour,Controls.IBoatControlActions {

    private Vector2 moveDir;

    [Header("Components")]
    [SerializeField] private Health health;
    [SerializeField] private Mover mover;

    private Controls control;
    public void OnFire1(InputAction.CallbackContext context) {
        throw new System.NotImplementedException();
    }

    public void OnFire2(InputAction.CallbackContext context) {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context) {
        moveDir = context.ReadValue<Vector2>();
    }

    private void Awake() {
        mover = GetComponent<Mover>();
        health = GetComponent<Health>();
        control = new Controls();
        control.BoatControl.SetCallbacks(this);
        control.BoatControl.Enable();
    }
    void Start()
    {
        
    }

    void Update()
    {
        mover.Move(moveDir);
    }

    private void OnDestroy() {
        control.BoatControl.Disable();
    }
}
