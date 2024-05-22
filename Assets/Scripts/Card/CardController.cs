using CardGame.GameRoom;
using UnityEngine;

namespace CardGame.Card
{
    public class CardController
    {
        private CardView cardView;
        private GameRoomService gamerRoomService;
        private CardSO cardSO;
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
        }
    }
}