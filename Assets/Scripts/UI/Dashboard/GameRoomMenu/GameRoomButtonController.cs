using CardGame.GameRoom;
using CardGame.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardGame.UI.Dashboard
{
    public class GameRoomButtonController
    {
        private GameRoomButtonView gameRoomButtonView;
        private GameRoomSO gameRoomSO;
        public GameRoomButtonController(GameRoomButtonView prefab, Transform container)
        {
            InitView(prefab, container);
        }

        public void Init(GameRoomSO gameRoomSO)
        {
            this.gameRoomSO = gameRoomSO;
            gameRoomButtonView.SetButtonText(gameRoomSO.ShortTitle);
        }
        private void InitView(GameRoomButtonView prefab, Transform container)
        {
            gameRoomButtonView = UnityEngine.Object.Instantiate(prefab, container);
            gameRoomButtonView.SetController(this);

        }

        public void OnRoomButtonClick()
        {
            CommonDataService.Instance.SelectedGameRoom = gameRoomSO;
            SceneManager.LoadScene(2);
        }
    }

}