using CardGame.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.GameRoom
{
    [System.Serializable]
    public struct GameRoomData
    {
        public int GameRoomID;
        public List<CardModel> Deck;

    }
}
