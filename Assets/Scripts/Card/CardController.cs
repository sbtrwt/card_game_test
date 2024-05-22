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
        private CardModel cardModel;

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
            this.cardModel = new CardModel { CardType = cardSO.CardTYPE, CardNumber = cardSO.CardNumber };
            this.gamerRoomService = gamerRoomService;
            SetState(CardState.CLOSED);
            cardView.gameObject.SetActive(true);
          
        }

        public void OpenCard() 
        {
            SetState(CardState.OPENED);
            SetCardFaceSprite();
        }
       

        public void OnCardClickDown() 
        {
            if (cardView.ValidateClickAction())
            {
                //Debug.Log("Mouse down");
                if (currentState == CardState.CLOSED)
                { OpenCard(); }
                
                gamerRoomService.SetSelectedCardController(this);

            }

        }
        public void SetParentContainer(Transform parentContainer) 
        {
            cardView.gameObject.transform.SetParent(parentContainer);
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

        public CardModel GetCardModel() => cardModel;
      
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