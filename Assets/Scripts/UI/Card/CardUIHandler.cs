using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using CardGame.Card;

namespace CardGame.UI.Card
{
    public class CardUIHandler : MonoBehaviour
    {
     
        private CardController owner;
        private Vector3 offsetPosition;
        private Vector3 originalPosition;
        private bool isDragging = false;
        private Camera mainCamera;
        public void ConfigureImageHandler( CardController owner)
        {
            this.owner = owner;
        }

        private void Awake()
        {
            if (!mainCamera) mainCamera = Camera.main;
            //originalPosition = transform.position;
            //originalAnchoredPosition = transform.position;
        }
        private void Update()
        {
            if (isDragging)
            {
                transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;
            }
        }
        private void OnMouseDown()
        {
            Debug.Log("Mouse down");
            originalPosition = transform.position;
            offsetPosition = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        private void OnMouseUp()
        {
            Debug.Log("Mouse up");
            ResetCardImage();
            //owner.CardDraggedAt(transform.position);
            isDragging = false;
        }
       
        private void ResetCardImage()
        {
            transform.position = originalPosition;
        
        }
    }
}