
using CardGame.Events;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame.UI.Room
{
    public class RoomUIService : MonoBehaviour
    {
        [SerializeField] private Button deckButton;
        [SerializeField] private Button dropButton;

        private EventService eventService;
        private void Start()
        {
            deckButton.onClick.AddListener(OnClickDeckButton);
            dropButton.onClick.AddListener(OnClickDropButton);
        }

        public void Init(EventService eventService)
        {
            this.eventService = eventService;
        }
      
        private void OnClickDeckButton()
        {
            eventService.OnCardDraw.InvokeEvent(1);
        }

        private void OnClickDropButton()
        {
            eventService.OnCardDrop.InvokeEvent(1);
        }
    }

}