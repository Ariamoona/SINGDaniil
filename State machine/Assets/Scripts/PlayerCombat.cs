using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] public GameObject BulletPrefab;
    [SerializeField] public Transform FirePoint;
    [SerializeField] public SpriteRenderer PlayerSprite;
    [SerializeField] public GameObject RedZone;
    [SerializeField] public KeyCode AttackKey = KeyCode.Mouse0;

    public void ToggleTransparency(bool transparent)
    {
        Color color = PlayerSprite.color;
        color.a = transparent ? 0.5f : 1f;
        PlayerSprite.color = color;
    }
}