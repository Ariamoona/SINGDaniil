using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject _staticObject;
    [SerializeField] private GameObject _movingObject;

    private Score _score;
    private Camera _mainCamera;

    public void Initialize(Score score)
    {
        _score = score;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            HandleClick();
    }

    private void HandleClick()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject == _staticObject)
                _score.ModifyScore(-1);
            else if (hit.collider.gameObject == _movingObject)
                _score.ModifyScore(1);
        }
    }
}