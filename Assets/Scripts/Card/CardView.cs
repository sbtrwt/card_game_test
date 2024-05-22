using CardGame.UI.Card;
using UnityEngine;
namespace CardGame.Card
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D boxCollider2D;
        [SerializeField] private SpriteRenderer faceSpriteRenderer;
        private CardController controller;
                
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
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                controller?.OnCardClickDown();
            }
            if (Input.GetMouseButtonUp(0))
            {
                controller?.OnCardClickUp();

            }
#endif
#if UNITY_ANRDOID
            if (Input.touchCount >= 1)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    controller?.OnCardClickDown();
                }

                if (Input.touches[0].phase == TouchPhase.Ended)
                {
                    controller?.OnCardClickUp();
                }
            }
#endif

        }

        public bool ValidateClickAction() 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && boxCollider2D.Equals(hit.collider))
            {
                return true;
            }
            return false;
        }

        
        public void SetCardFaceSprite()
        {
            controller.SetCardFaceSprite(faceSpriteRenderer);

        }
    }
}