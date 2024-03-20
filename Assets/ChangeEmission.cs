using UnityEngine;
using UnityEngine.UI;

public class ChangeEmission : MonoBehaviour
{
    [SerializeField]
    private Material myMaterial;

    public Texture[] emissionTextures;
    private int currentIndex = 0;

    public Renderer[] targetRenderers; // Array of Renderers

    void Start()
    {
        //Button button = GetComponent<Button>();
        //button.onClick.AddListener(ChangeMaterialAndEmission);
    }

   public void ChangeMaterialAndEmission()
    {
        // Change the material and emission texture for each renderer in the array
        foreach (Renderer renderer in targetRenderers)
        {
            renderer.material = myMaterial; // Apply the material to the renderer
            renderer.material.SetTexture("_EmissionMap", emissionTextures[currentIndex]);
            renderer.material.SetColor("_EmissionColor", Color.white);
        }

        // Move to the next texture or loop back to the first one
        currentIndex = (currentIndex + 1) % emissionTextures.Length;
    }
}
