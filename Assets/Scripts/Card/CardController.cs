using UnityEngine;

namespace CardGame.Card
{
    public class CardController
    {
        private CardView cardView;
        private CardSO cardSO;
        public CardController(CardSO cardSO, Transform cardContainer) 
        {
            this.cardSO = cardSO;
            InitView(cardSO.CardViewPrefab, cardContainer);
        }

        public void InitView(CardView cardViewPrefab, Transform cardContainer) 
        {
            cardView = UnityEngine.Object.Instantiate(cardViewPrefab, cardContainer);
            cardView.SetController(this);
        }
    }
}