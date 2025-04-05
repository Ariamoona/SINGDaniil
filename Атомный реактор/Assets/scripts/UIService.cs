using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    private static UIService instance;
    public static UIService Instance => instance;

    [SerializeField] private ResourceUIDataSO resourceUIDataSO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetActiveSprite(ResourceType type, Image image)
    {
        foreach (var resourceUI in resourceUIDataSO.resourcesUI)
        {
            if (resourceUI.type == type)
            {
                image.sprite = resourceUI.activeSprite;
                return;
            }
        }
    }

    public void SetInactiveSprite(ResourceType type, Image image)
    {
        foreach (var resourceUI in resourceUIDataSO.resourcesUI)
        {
            if (resourceUI.type == type)
            {
                image.sprite = resourceUI.inactiveSprite;
                return;
            }
        }
    }
}
