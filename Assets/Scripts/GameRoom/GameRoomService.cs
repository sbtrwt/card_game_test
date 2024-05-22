using CardGame.Card;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.GameRoom
{
    public class GameRoomService 
    {
        private GameRoomSO gameRoomSO;
        private Stack<CardModel> currentDeck;
        private List<CardModel> baseDeck;
        public GameRoomService(GameRoomSO gameRoomSO)
        {
            this.gameRoomSO = gameRoomSO;
            InitBaseDeck();
            SuffleDeck();
        }
        private void InitBaseDeck() 
        {
            baseDeck = new List<CardModel>();
            if(gameRoomSO.GameRoomConfigurationSO.GameRoomData.Deck == null || gameRoomSO.GameRoomConfigurationSO.GameRoomData.Deck.Count == 0)
            {
                foreach(CardType type in Enum.GetValues(typeof(CardType)))
                {
                    foreach (CardNumber number in Enum.GetValues(typeof(CardNumber)))
                    {
                        if(type != CardType.NONE && number != CardNumber.NONE)
                        baseDeck.Add(new CardModel { CardType = type, CardNumber = number });
                    }
                }
            }
            else
            {
                foreach(var card in gameRoomSO.GameRoomConfigurationSO.GameRoomData.Deck)
                {
                    baseDeck.Add(new CardModel { CardType = card.CardType, CardNumber = card.CardNumber });
                }
            }
            
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
                tempDeck.RemoveAt(indexToPush);
                count--;
            }
        }
    }
}