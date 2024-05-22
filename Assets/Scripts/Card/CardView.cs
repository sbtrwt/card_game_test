using CardGame.UI.Card;
using UnityEngine;
namespace CardGame.Card
{
    public class CardView : MonoBehaviour
    {
        private CardController controller;

        private Vector3 offsetPosition;
        private Vector3 originalPosition;
        private bool isDragging = false;
        private Camera mainCamera;

        private void Awake()
        {
            if (!mainCamera) mainCamera = Camera.main;
        }
        public void SetController(CardController controller)
        {
            this.controller = controller;
           
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnCardMouseDown();
            }
            if (Input.GetMouseButtonUp(0))
            {
                OnCardMouseUp();
            }
            if (isDragging)
            {
                OnCardMouseDrag();
            }
        }
        private void OnCardMouseDown()
        {
            Debug.Log("Mouse down");
            originalPosition = transform.position;
            offsetPosition = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        private void OnCardMouseUp()
        {
            Debug.Log("Mouse up");
            ResetCardImage();
            //controller.CardDraggedAt(transform.position);
            isDragging = false;
        }
        private void OnCardMouseDrag()
        {
            Debug.Log("Mouse drag");
            transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;

            //controller.SetPosition(mainCamera.ScreenToWorldPoint(Input.mousePosition) + offsetPosition);
        }
        private void ResetCardImage()
        {
            transform.position = originalPosition;

        }
    }
}