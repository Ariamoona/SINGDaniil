using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        Game.Instance.Initialize();
    }
}
