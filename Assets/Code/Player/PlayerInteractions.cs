using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void Start()
    {
        CreateCollider();
    }
    
    private void CreateCollider()
    {
        GameObject interaction = new();
        interaction.name = "Interaction Collider";
        interaction.transform.SetParent(transform);
        CapsuleCollider2D capsuleCollider2D = interaction.AddComponent<CapsuleCollider2D>();
        capsuleCollider2D.isTrigger = true;
        capsuleCollider2D.offset = new Vector2(0, 0.03f);
        capsuleCollider2D.size = new Vector2(0.3f, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag($"Interactable")) return;
        other.GetComponent<IInteractable>()?.EnableInteract();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag($"Interactable")) return;
        other.GetComponent<IInteractable>()?.DisableInteract();
    }
}
