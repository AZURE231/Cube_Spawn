using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] AudioSource soundDestroy;

    [Header("Explosion tune")]
    [SerializeField] float explosionForce = 0f;
    [SerializeField] float affectRadius = 0f;

    private Camera cam = null;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        DestroyCubeAtMousePosition();
    }
    public void ApplyExplosionForce(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, affectRadius);

        foreach (Collider affectedObjects in colliders)
        {
            if (affectedObjects.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(explosionForce, position, affectRadius, 1.0f, ForceMode.Impulse);
        }
    }

    public void DestroyCubeAtMousePosition()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "Cube(Clone)")
                {
                    Debug.Log(hit.transform.position);
                    ApplyExplosionForce(hit.transform.position);
                    soundDestroy.Play();
                    Destroy(hit.transform.gameObject);
                }
                //Debug.Log(hit.transform.gameObject.name);

            }
        }
    }
}
