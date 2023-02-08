using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCube : MonoBehaviour
{
    [SerializeField] Color mouseOverColor = Color.blue;
    Color originalColor;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        meshRenderer = GetComponent<MeshRenderer>(); 
        //Fetch the original color of the GameObject
        originalColor = meshRenderer.material.color;
    }

    // On hover the object, change color
    private void OnMouseOver()
    {
        meshRenderer.material.color = mouseOverColor;
    }

    // Return to the origin color when move out
    private void OnMouseExit()
    {
        meshRenderer.material.color = originalColor;
    }
}
