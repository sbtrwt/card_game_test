using System.Collections.Generic;
using UnityEngine;

namespace CardGame.GameRoom
{
    [CreateAssetMenu(fileName = "GameRoomConfiguration", menuName = "ScriptableObjects/GameRoomConfiguration")]
    public class GameRoomConfigurationSO : ScriptableObject
    {
        public int GameRoomID;
        public GameRoomData GameRoomData;
    }
}
