
using CardGame.Events;
using CardGame.Main;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CardGame.UI.Room
{
    public class RoomUIService : MonoBehaviour
    {
        [SerializeField] private Button deckButton;
        [SerializeField] private Button dropButton;
        [SerializeField] private Button lobbyButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private GameObject gameOverPanel;

        private EventService eventService;
        private void Start()
        {
            deckButton.onClick.AddListener(OnClickDeckButton);
            dropButton.onClick.AddListener(OnClickDropButton);
            lobbyButton.onClick.AddListener(OnClickLobbyButton);
            closeButton.onClick.AddListener(OnClickLobbyButton);

        }
       
        public void Init(EventService eventService)
        {
            this.eventService = eventService;
            SubscribeEvents();
        }
        public void SubscribeEvents()
        {
            eventService.OnGameOver.AddListener(OnGameOver);
        }

        private void OnClickDeckButton()
        {
            eventService.OnCardDraw.InvokeEvent(1);
        }

        private void OnClickDropButton()
        {
            eventService.OnCardDrop.InvokeEvent(1);
        }

        private void OnClickLobbyButton()
        {
            SceneManager.LoadScene(GlobalConstant.DASHBOARD_INDEX);
        }
        private void OnGameOver(int flag)
        {
            SetGameOver(flag==1);
        }
        private void SetGameOver(bool isActive)
        {
            gameOverPanel.SetActive(isActive);
        }
    }

}