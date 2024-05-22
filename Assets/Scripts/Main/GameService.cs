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

        private void Start()
        {
            InitializeServices();
        }

        private void InitializeServices()
        {
            gameRoomService = new GameRoomService(gameRoomSO);
        }
    }
}