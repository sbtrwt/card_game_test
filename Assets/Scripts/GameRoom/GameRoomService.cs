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
        private Transform cardContainer;
        private EventService eventService;
        private CardController selectedCardController;
        private CardController prevDroppedCardController;
        public GameRoomService(GameRoomSO gameRoomSO)
        {
            this.gameRoomSO = gameRoomSO;
            InitBaseDeck();

        }
        public void Init(Transform cardContainer, Transform dropCardContainer, EventService eventService)
        {
            this.cardContainer = cardContainer;
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
            eventService.OnCardDrop.AddListener(OnCardDrop);
        }
        private void OnCardDraw(int count)
        {
            DrawCards(count);
        }
        private void OnCardDrop(int count)
        {
            RemoveCardFromPlayer(selectedCardController);

            //check for win total
            if (ActiveCardsTotal() == gameRoomSO.WinTotal) 
            {
                //Game result window
                eventService.OnGameOver.InvokeEvent(1);
            }
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

        public void RemoveCardFromPlayer (CardController cardController)
        {
            if (cardController == null) return;
            if (activeCards != null && activeCards.Count > 0)
            {
                activeCards.Remove(cardController);
            }
            AddCardToDropTable(cardController);
           
        }

        public void SetSelectedCardController(CardController cardController) => selectedCardController = cardController;
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
            if (currentDeck.Count > 0)
            {
                for (int i = 0; i < cardCount; i++)
                {
                    CardModel carDrew = currentDeck.Pop();
                    CardController cardController = cardPool.GetCard(carDrew.CardType, carDrew.CardNumber);
                    Debug.Log(carDrew.CardType + " " + carDrew.CardNumber);
                    activeCards.Add(cardController);
                    cardController.SetParentContainer(cardContainer);
                }
                ConfigureCardPosition();
            }
        }
        private void ConfigureCardPosition()
        {
            int count = activeCards.Count;
            float cardWidth = 1.8f;
            float positionX = (cardWidth - (count * cardWidth)) / 2f;
            for (int i = 0; i < count; i++)
            {
                activeCards[i].SetPosition(new Vector3(positionX, 0, 0));
                positionX += cardWidth;
            }
        }

        private void AddCardToDropTable(CardController cardController) 
        {
            cardController.SetParentContainer(dropCardContainer);
            cardController.SetPosition(new Vector3(0, 0, 0));
            if(prevDroppedCardController != null)
            {
                cardPool.ReturnItem(prevDroppedCardController);
                prevDroppedCardController.ResetCard();
            }
            if (cardController != null)
            {
                currentDropDeck.Push(cardController.GetCardModel());
            }
            prevDroppedCardController = cardController;
        }
        private void GameStart()
        {
            SuffleDeck();
            DrawCards(3);
        }

        private int ActiveCardsTotal() 
        {
            int sum = 0;
            CardModel cardModel;
            foreach(CardController card in activeCards)
            {
                cardModel =  card.GetCardModel();
                sum += Convert.ToInt32(cardModel.CardNumber);
            }
            return sum;
        }
    }
}