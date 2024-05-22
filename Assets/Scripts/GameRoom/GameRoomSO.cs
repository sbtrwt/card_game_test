using CardGame.Card;
using System.Collections.Generic;
using UnityEngine;


namespace CardGame.GameRoom
{
    [CreateAssetMenu(fileName = "GameRoomScriptableObject", menuName = "ScriptableObjects/GameRoomScriptableObject")]
    public class GameRoomSO : ScriptableObject
    {
        public int ID;
        public string ShortTitle;
        public List<CardSO> CardScriptableObjects;
        public GameRoomConfigurationSO GameRoomConfigurationSO;
        public CardView DefulatCardViewPrefab;
    }
}
