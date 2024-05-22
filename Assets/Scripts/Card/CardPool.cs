using CardGame.GameRoom;
using CardGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CardGame.Card
{
    public class CardPool : GenericObjectPool<CardController>
    {
        private CardView cardViewPrefab;
        private List<CardSO> cardScriptableObjects;
        private Transform cardContainer;
        private GameRoomService gamerRoomService;
        public CardPool(GameRoomSO gameRoomSO, GameRoomService gamerRoomService, Transform cardContainer)
        {
            this.cardViewPrefab = gameRoomSO.DefulatCardViewPrefab;
            this.cardScriptableObjects = gameRoomSO.CardScriptableObjects;
            this.cardContainer = cardContainer;
            this.gamerRoomService = gamerRoomService;
        }

        public CardController GetCard(CardType cardType, CardNumber cardNumber)
        {
            CardController cardController = GetItem();
            CardSO scriptableObjectToUse = cardScriptableObjects.Find(so => so.CardTYPE == cardType && so.CardNumber== cardNumber);
            cardController.Init(scriptableObjectToUse, gamerRoomService);
            return cardController;
        }

        protected override CardController CreateItem() => new CardController(cardViewPrefab, cardContainer);
    }
}
