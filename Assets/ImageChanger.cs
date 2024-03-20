using System.Collections;
using UnityEngine;
public class ImageChanger : MonoBehaviour
{
    public Material[] imageMaterials; // Array of materials (images)
    public Renderer planeRenderer;
    private int currentImageIndex = 0;
    void Start()
    {
        //planeRenderer = GetComponentInChildren<Renderer>();
        UpdatePlaneMaterial();
    }

   public void ChangeImage()
    {
        currentImageIndex = (currentImageIndex + 1) % imageMaterials.Length;
        UpdatePlaneMaterial();
    }
    void UpdatePlaneMaterial()
    {
        planeRenderer.material = imageMaterials[currentImageIndex];
    }
}