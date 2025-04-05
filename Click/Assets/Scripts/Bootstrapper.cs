using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private GameObject _movingObject;

    private Score _score;
    private Game _game;

    private void Awake()
    {
        _score = new Score();
        _game = new Game(_score);

        _gameUI.Initialize(_score);
        _clickHandler.Initialize(_score);

        SetupMovingObject();
        _game.StartGame();
    }

    private void SetupMovingObject()
    {
        var joint = _movingObject.AddComponent<HingeJoint>();
        var motor = joint.motor;
        motor.force = 10f;
        motor.targetVelocity = 180f;
        joint.motor = motor;
        joint.useMotor = true;
    }
}