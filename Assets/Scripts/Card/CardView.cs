using UnityEngine;
namespace CardGame.Card
{
    public class CardView : MonoBehaviour
    {
        private CardController controller;
        public void SetController(CardController controller)
        {
            this.controller = controller;
        }
    }
}