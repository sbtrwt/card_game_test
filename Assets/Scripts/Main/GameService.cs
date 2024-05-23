using CardGame.Events;
using CardGame.GameRoom;
using CardGame.UI.Room;
using UnityEngine;
namespace CardGame.Main
{
    public class GameService : MonoBehaviour
    {
        private GameRoomService gameRoomService;
        private EventService eventService;

        [SerializeField] private GameRoomSO gameRoomSO;

        [SerializeField] private Transform playerCardContainer;
        [SerializeField] private Transform dropCardContainer;

        [SerializeField] private RoomUIService roomUIService;
        private void Start()
        {
            SetGameRoomSO();
            InitializeServices();
            InjectDependencies();
        }

        private void SetGameRoomSO()
        {
            if (CommonDataService.Instance)
            {
                gameRoomSO = CommonDataService.Instance.SelectedGameRoom;
            }
        }
        private void InitializeServices()
        {
            gameRoomService = new GameRoomService(gameRoomSO);
            eventService = new EventService();
        }
        private void InjectDependencies()
        {
            gameRoomService.Init(playerCardContainer, dropCardContainer, eventService);
            roomUIService.Init(eventService);


        }
    }
}