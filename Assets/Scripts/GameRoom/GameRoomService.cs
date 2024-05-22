using CardGame.Card;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.GameRoom
{
    public class GameRoomService
    {
        private GameRoomSO gameRoomSO;
        private Stack<CardModel> currentDeck;
        private List<CardModel> baseDeck;
        private CardPool cardPool;
        private List<CardController> activeCards;

        public GameRoomService(GameRoomSO gameRoomSO)
        {
            this.gameRoomSO = gameRoomSO;
            InitBaseDeck();
            SuffleDeck();
        }
        public void Init()
        {
            InitializeCards();
        }
        private void InitBaseDeck()
        {
            baseDeck = new List<CardModel>();
            if (gameRoomSO.GameRoomConfigurationSO.GameRoomData.Deck == null || gameRoomSO.GameRoomConfigurationSO.GameRoomData.Deck.Count == 0)
            {
                foreach (CardType type in Enum.GetValues(typeof(CardType)))
                {
                    if (type == CardType.NONE)
                    {
                        continue;
                    }
                    foreach (CardNumber number in Enum.GetValues(typeof(CardNumber)))
                    {
                        if (number == CardNumber.NONE) continue;

                        baseDeck.Add(new CardModel { CardType = type, CardNumber = number });
                    }

                }
            }
            else
            {
                foreach (var card in gameRoomSO.GameRoomConfigurationSO.GameRoomData.Deck)
                {
                    baseDeck.Add(new CardModel { CardType = card.CardType, CardNumber = card.CardNumber });
                }
            }

        }

        public void RemoveCard(CardController cardController)
        {
          
        }

        private void SuffleDeck()
        {
            List<CardModel> tempDeck = new List<CardModel>(baseDeck);

            int count = tempDeck.Count;
            int indexToPush;
            currentDeck = new Stack<CardModel>();

            while (count > 0)
            {
                indexToPush = UnityEngine.Random.Range(0, count);
                currentDeck.Push(tempDeck[indexToPush]);
                Debug.Log(tempDeck[indexToPush].CardType + " " + tempDeck[indexToPush].CardNumber);
                tempDeck.RemoveAt(indexToPush);
                count--;
            }
        }
        private void InitializeCards()
        {
            cardPool = new CardPool(gameRoomSO, this);
            activeCards = new List<CardController>();
        }
    }
}