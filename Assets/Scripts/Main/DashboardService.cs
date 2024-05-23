using CardGame.GameRoom;
using CardGame.UI.Dashboard;
using CardGame.Utilities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CardGame.Main
{
    public class DashboardService : MonoBehaviour
    {
        private DashboardUIService dashBoardUIService;

        [SerializeField] private DashboardUISO dashboardUISO;
        [SerializeField] private Transform gameRoomMenuContainer;
        [SerializeField] private Button historyButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private GameObject historyPanel;
        private void Start()
        {
            if (ApplicationValidator.IsValidUser())
            {
                InitializeServices();
            }
            else
            {
                ShowLogin();
            }
        }
        private void InitializeServices()
        {
            dashBoardUIService = new DashboardUIService(dashboardUISO, gameRoomMenuContainer, historyButton, closeButton, historyPanel);
        }

        private void ShowLogin()
        {
            SceneManager.LoadScene(GlobalConstant.LOGIN_INDEX);
        }

    }

}