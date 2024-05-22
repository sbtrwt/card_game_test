using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Card
{
    [System.Serializable]
    public class CardModel
    {
        CardType CardType { get; set; }
        CardNumber CardNumber { get; set; }
    }
}
