using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMoveInput;
    public UnityEvent OnAttackInput;
    
    [SerializeField] private string moveHorizontalAxis = "Horizontal";
    [SerializeField] private string moveVerticalAxis = "Vertical";
    [SerializeField] private KeyCode attackKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode switchStateKey = KeyCode.Return;

    private void Update()
    {
        HandleMovementInput();
        HandleAttackInput();
        HandleStateSwitch();
    }

    private void HandleMovementInput()
    {
        Vector2 input = new Vector2(
            Input.GetAxisRaw(moveHorizontalAxis),
            Input.GetAxisRaw(moveVerticalAxis)
        );
        OnMoveInput?.Invoke(input);
    }

    private void HandleAttackInput()
    {
        if (Input.GetKeyDown(attackKey))
            OnAttackInput?.Invoke();
    }

    private void HandleStateSwitch()
    {
        if (Input.GetKeyDown(switchStateKey))
            GameStateMachine.Instance.SwitchToNextState();
    }
}