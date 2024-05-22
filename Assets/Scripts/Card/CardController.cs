using CardGame.GameRoom;
using System;
using UnityEngine;

namespace CardGame.Card
{
    public class CardController
    {
        private CardView cardView;
        private GameRoomService gamerRoomService;
        private CardSO cardSO;
        private CardState currentState;

        public CardController(CardView cardViewPrefab, Transform cardContainer) 
        {
            InitView(cardViewPrefab, cardContainer);
        }

        private void InitView(CardView cardViewPrefab, Transform cardContainer) 
        {
            cardView = UnityEngine.Object.Instantiate(cardViewPrefab, cardContainer);
            cardView.SetController(this);
        }
        public void Init(CardSO cardSO, GameRoomService gamerRoomService)
        {
            this.cardSO = cardSO;
            this.gamerRoomService = gamerRoomService;
            SetState(CardState.CLOSED);
            cardView.gameObject.SetActive(true);
          
        }

        public void OpenCard() 
        {
            SetState(CardState.OPENED);
            SetCardFaceSprite();
        }
        private void ResetCard()
        {
            gamerRoomService.RemoveCard(this);
            cardView.gameObject.SetActive(false);

        }

        public void OnCardClickDown() 
        {
            if (cardView.ValidateClickAction())
            {
                //Debug.Log("Mouse down");
                if (currentState == CardState.CLOSED)
                OpenCard();
            }

        }
        public void OnCardClickUp()
        {
            if (cardView.ValidateClickAction())
            {
                //Debug.Log("Mouse up");
            }
        }
        public void SetCloseSprite(SpriteRenderer spriteRenderer)
        {
            spriteRenderer.sprite = cardSO.CloseFace;
        }
      
        public void SetCardFaceSprite(SpriteRenderer spriteRenderer)
        {
            if(spriteRenderer && cardSO)
            spriteRenderer.sprite = (currentState == CardState.OPENED)? cardSO.OpenFace : cardSO.CloseFace;
        }
        public void SetCardFaceSprite()
        {
            cardView.SetCardFaceSprite();
        }

        public void SetPosition(Vector3 positionToSet) => cardView.gameObject.transform.localPosition = positionToSet;
        private void SetState(CardState state) => currentState = state;
        public enum CardState
        {
            CLOSED,
            OPENED,
            HIDDEN
        }

      
    }
}