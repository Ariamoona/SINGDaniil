using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceButton : MonoBehaviour
{
    [SerializeField] private ResourceType resourceType;
    [SerializeField] private Image resourceImage;

    private Button button;
    private ResourceData resourceData;
    private Coroutine decayCoroutine;
    private Coroutine enrichmentCoroutine;

    private void Awake()
    {
        button = GetComponent<Button>();
        resourceData = ResourceService.Instance.GetResourceData(resourceType);
        UIService.Instance.SetActiveSprite(resourceType, resourceImage);
    }

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
        StartDecayTimer();
    }

    private void StartDecayTimer()
    {
        if (decayCoroutine != null) StopCoroutine(decayCoroutine);
        decayCoroutine = StartCoroutine(DecayTimer());
    }

    private IEnumerator DecayTimer()
    {
        yield return new WaitForSeconds(resourceData.decayTime);
        if (Game.Instance.IsGameActive)
        {
            Game.Instance.GameOver();
        }
    }

    private void OnButtonClick()
    {
        if (!Game.Instance.IsGameActive) return;

        StartEnrichmentTimer();
    }

    private void StartEnrichmentTimer()
    {
        if (enrichmentCoroutine != null) StopCoroutine(enrichmentCoroutine);
        enrichmentCoroutine = StartCoroutine(EnrichmentTimer());
    }

    private IEnumerator EnrichmentTimer()
    {
        button.interactable = false;
        UIService.Instance.SetInactiveSprite(resourceType, resourceImage);

        yield return new WaitForSeconds(resourceData.enrichmentTime);

        button.interactable = true;
        UIService.Instance.SetActiveSprite(resourceType, resourceImage);
        StartDecayTimer();
    }
}