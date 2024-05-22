using CardGame.GameRoom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardGame.Main
{
    public class GameService : MonoBehaviour
    {
        private GameRoomService gameRoomService;

        
        [SerializeField] private GameRoomSO gameRoomSO;

        [SerializeField] private Transform playerCardContainer;
        [SerializeField] private Transform dropCardContainer;

        private void Start()
        {
            InitializeServices();
            InjectDependencies();
        }

        private void InitializeServices()
        {
            gameRoomService = new GameRoomService(gameRoomSO);
        }
        private void InjectDependencies()
        {
            gameRoomService.Init(playerCardContainer, dropCardContainer);
           
        }
    }
}