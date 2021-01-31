using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TaxiManager.Controls
{
    
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float panSpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float zoomSpeed;
        private Vector3 _panMovement;
        private float _rotation;
        private Vector3 _zoomMovement;

        private void Update()
        {
            transform.position += _panMovement;
            transform.RotateAround(transform.position, Vector3.up, _rotation);
            transform.position += _zoomMovement;
        }

        public void Pan(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            _panMovement = new Vector3(value.x, 0, value.y) * panSpeed * Time.deltaTime;
        }

        public void Rotate(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            _rotation = value * rotateSpeed * Time.deltaTime;
        }

        public void Zoom(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            _zoomMovement = transform.forward * value * zoomSpeed * Time.deltaTime;
        }
        
    }
    
}
