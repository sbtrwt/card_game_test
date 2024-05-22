using System.Collections.Generic;
using UnityEngine;

namespace CardGame.GameRoom
{
    [CreateAssetMenu(fileName = "GameRoomConfiguration", menuName = "ScriptableObjects/GameRoomConfiguration")]
    public class GameRoomConfiguration : ScriptableObject
    {
        public int GameRoomID;
        public List<GameRoomData> WaveDatas;
    }
}
