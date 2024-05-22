using CardGame.GameRoom;
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
        private void ResetCard()
        {
            gamerRoomService.RemoveCard(this);
            cardView.gameObject.SetActive(false);

        }

        private void SetState(CardState state) => currentState = state;
        public enum CardState
        {
            CLOSED,
            OPENED,
            HIDDEN
        }
    }
}