using UnityEngine;

namespace _Scripts.Controllers
{
    public class CameraController : MonoBehaviour
    {
        public Transform object1;  // Reference to the first object
        public Transform object2;  // Reference to the second object
        public float minDistance = 5f; // Minimum distance between camera and objects
        public float yPos = 5f; // Minimum distance between camera and objects
        public float moveSpeed = 5f; // Camera movement speed

        private Camera cam;

        private void Start()
        {
            cam = GetComponent<Camera>();
        }

        private void Update()
        {
            // Calculate the bounds that encompass both objects
            Bounds bounds = new Bounds();
            bounds.Encapsulate(object1.position);
            bounds.Encapsulate(object2.position);

            // Calculate the camera's position based on the bounds
            Vector3 targetPosition = bounds.center - cam.transform.forward * Mathf.Max(bounds.extents.magnitude + minDistance, minDistance);

            targetPosition.y = yPos;
            // Smoothly move the camera towards the target position
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}