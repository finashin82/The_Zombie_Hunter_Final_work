using UnityEngine;
using UnityEngine.InputSystem;

public class InputData : MonoBehaviour
{
    public InputSystem_Actions inputActions;

    public Vector2 inputVector;

    public bool isAttackBegin = false;

    public bool isSprint = false;

    private void Awake()
    {
        // Активируем контроллер ввода
        inputActions = new InputSystem_Actions();

        // Подписываемся на событие нажатия клавиш движения
        inputActions.Player.Move.started += OnMoveStarted;
        inputActions.Player.Move.performed += OnMovePerformed;
        inputActions.Player.Move.canceled += OnMoveCanceled;

        // Подписываемся на событие нажатия клавиш атаки
        inputActions.Player.Attack.started += OnAttackStarted;
        inputActions.Player.Attack.performed += OnAttackPerformed;
        inputActions.Player.Attack.canceled += OnAttackCanceled;

        // Подписываемся на событие нажатия клавиш ускорения
        inputActions.Player.Sprint.started += OnSprintStarted;
        inputActions.Player.Sprint.performed += OnSprintPerformed;
        inputActions.Player.Sprint.canceled += OnSprintCanceled;
    }

    public void OnEnable()
    {
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }    

    public void OnMoveStarted(InputAction.CallbackContext context)
    {

    }     

    public void OnMovePerformed(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void OnMoveCanceled(InputAction.CallbackContext context)
    {
        inputVector = Vector2.zero;
    }

    public void OnAttackStarted(InputAction.CallbackContext context)
    {
        
    }

    public void OnAttackPerformed(InputAction.CallbackContext context)
    {
        isAttackBegin = true;
    }

    public void OnAttackCanceled(InputAction.CallbackContext context)
    {
        isAttackBegin = false;
    }

    public void OnSprintStarted(InputAction.CallbackContext context)
    {

    }

    public void OnSprintPerformed(InputAction.CallbackContext context)
    {
        isSprint = true;
    }

    public void OnSprintCanceled(InputAction.CallbackContext context)
    {
        isSprint = false;
    }
}
