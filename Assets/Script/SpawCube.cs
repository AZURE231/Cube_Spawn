using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class SpawCube : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] AudioSource soundAppear;

    private Camera cam = null;
    private float gapFromWall = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SpawAtMousePosition();
    }

    private void SpawAtMousePosition()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "PlaneFront")
                {
                    Instantiate(cubePrefab, new Vector3(hit.point.x, hit.point.y, hit.point.z - gapFromWall),
                    Quaternion.identity);    // Quaternion.identity the rotation already apply to the prefab
                }
                 else if (hit.transform.gameObject.name == "PlaneRight")
                {
                    Instantiate(cubePrefab, new Vector3(hit.point.x - gapFromWall, hit.point.y, hit.point.z),
                    Quaternion.identity);     
                }
                else if (hit.transform.gameObject.name == "PlaneLeft")
                {
                    Instantiate(cubePrefab, new Vector3(hit.point.x + gapFromWall, hit.point.y, hit.point.z),
                    Quaternion.identity);     
                }
                
                soundAppear.Play();
                //Debug.Log(hit.transform.gameObject.name);
            }
        }
        // Destroy cube when click on that cube
    }
    
}
