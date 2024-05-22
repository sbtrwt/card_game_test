using CardGame.Card;
using CardGame.Events;
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
        private Stack<CardModel> currentDropDeck;
        private Transform dropCardContainer;
        private EventService eventService;
        public GameRoomService(GameRoomSO gameRoomSO)
        {
            this.gameRoomSO = gameRoomSO;
            InitBaseDeck();
          
        }
        public void Init(Transform cardContainer, Transform dropCardContainer, EventService eventService)
        {
            this.eventService = eventService;
            this.dropCardContainer = dropCardContainer;
            InitializeCards(cardContainer);
            currentDropDeck = new Stack<CardModel>();

            GameStart();
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            eventService.OnCardDraw.AddListener(OnCardDraw);
        }
        private void OnCardDraw(int count) 
        {
            DrawCards(count);
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
                //Debug.Log(tempDeck[indexToPush].CardType + " " + tempDeck[indexToPush].CardNumber);
                tempDeck.RemoveAt(indexToPush);
                count--;
            }
        }
        private void InitializeCards(Transform cardContainer)
        {
            cardPool = new CardPool(gameRoomSO, this, cardContainer);
            activeCards = new List<CardController>();
        }

        private void DrawCards(int cardCount)
        {
            for(int i =0; i < cardCount; i++)
            {
                CardModel carDrew = currentDeck.Pop();
                CardController cardController = cardPool.GetCard(carDrew.CardType, carDrew.CardNumber);
                Debug.Log(carDrew.CardType + " " + carDrew.CardNumber);
                activeCards.Add(cardController);
            }
            ConfigureCardPosition();
        }
        private void ConfigureCardPosition()
        {
            int count = activeCards.Count;
            float cardWidth = 1.8f;
            float positionX = (cardWidth - (count * cardWidth)) / 2f;
            for(int i=0; i < count; i++)
            {
                activeCards[i].SetPosition(new Vector3(positionX, 0  , 0));
                positionX += cardWidth;
            }
        }
        private void GameStart()
        {
            SuffleDeck();
            DrawCards(3);
        }
    }
}