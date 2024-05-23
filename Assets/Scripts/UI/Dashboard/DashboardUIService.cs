using CardGame.GameRoom;
using CardGame.Player;
using CardGame.Player.History;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame.UI.Dashboard
{
    public class DashboardUIService 
    {
        private Transform parentContainer;

        private DashboardUISO dashboardUISO;
        private List<GameRoomButtonController> allGameRoomButtons;
        private Button historyButton;
        private Button closeButton;
        private GameObject historyPanel;
        private Transform historyContainer;
        private HistoryItemView historyItemViewPrefab;

        public DashboardUIService(DashboardUISO dashboardUISO, Transform container, Button historyButton, Button closeButton, GameObject historyPanel, Transform historyContainer, HistoryItemView historyPrefab)
        {
            this.dashboardUISO = dashboardUISO;
            this.parentContainer = container;
            this.historyButton = historyButton;
            this.closeButton = closeButton;
            this.historyPanel = historyPanel;
            this.historyContainer = historyContainer;
            this.historyItemViewPrefab = historyPrefab;

            RenderAllMenuButton();
            this.historyButton.onClick.AddListener(OnClickHistory);
            this.closeButton.onClick.AddListener(OnClickCloseHistory);
        }

        private void RenderAllMenuButton() 
        {
            allGameRoomButtons = new List<GameRoomButtonController>();
            GameRoomButtonController gameRoomButtonController;
            foreach (var room in dashboardUISO.GameRoomsSO)
            {
                gameRoomButtonController = new GameRoomButtonController(dashboardUISO.GameRoomButtonViewPrefab, parentContainer);
                gameRoomButtonController.Init(room);
                allGameRoomButtons.Add(gameRoomButtonController);

            }
        }

        private void OnClickHistory()
        {
            LoadHistory();
            historyPanel.SetActive(true);
        }
        private void OnClickCloseHistory()
        {
            historyPanel.SetActive(false);
        }

        private void LoadHistory() 
        {
            foreach (Transform child in historyContainer)
            {
                GameObject.Destroy(child.gameObject);
            }
            PlayerGameHistory playerGameHistory = new PlayerGameHistory();
            List<PlayerGameData> allPlayerGameData =   playerGameHistory.GetSavedHistory();
            HistoryItemController historyItemController; 
            foreach (var gameData in allPlayerGameData)
            {
                historyItemController = new HistoryItemController(historyItemViewPrefab, historyContainer);
                historyItemController.Init(gameData.GameShortName, gameData.PlayedOnText);
            }
        }
    }

}