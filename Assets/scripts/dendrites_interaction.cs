using UnityEngine;

public class dendrites_interaction : MonoBehaviour
{
    // Glissez le Canvas ou le TextMeshPro contenant "Dendrites" ici dans l'Inspecteur
    public GameObject texteAAfficher;

    // --- SOLUTION 1 : Utilisation avec Meta Interaction SDK (Poke) ---
    // Ces fonctions peuvent être appelées depuis un "Pointable Unity Event Wrapper"
    public void ShowText()
    {
        if (texteAAfficher != null)
        {
            texteAAfficher.SetActive(true);
        }
    }

    public void HideText()
    {
        if (texteAAfficher != null)
        {
            texteAAfficher.SetActive(false);
        }
    }

    // --- SOLUTION 2 : Utilisation avec les Collider physiques de Unity ---
    // Nécessite un BoxCollider (avec Is Trigger = true) sur cet objet
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Hand") || other.name.Contains("Sphere") || other.CompareTag("Player"))
        {
            ShowText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Hand") || other.name.Contains("Sphere") || other.CompareTag("Player"))
        {
            HideText();
        }
    }
}
