using UnityEngine;

public class ResourceService : MonoBehaviour
{
    private static ResourceService instance;
    public static ResourceService Instance => instance;

    [SerializeField] private ResourceDataSO resourceDataSO;

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

    public ResourceData GetResourceData(ResourceType type)
    {
        foreach (var resourceData in resourceDataSO.resourcesData)
        {
            if (resourceData.type == type)
            {
                return resourceData;
            }
        }
        return default;
    }
}
