using CardGame.GameRoom;
using CardGame.UI.Dashboard;
using CardGame.Utilities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardGame.Main
{
    public class DashboardService : MonoBehaviour
    {
        private DashboardUIService dashBoardUIService;

        [SerializeField] private DashboardUISO dashboardUISO;
        [SerializeField] private Transform gameRoomMenuContainer;

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
            dashBoardUIService = new DashboardUIService(dashboardUISO, gameRoomMenuContainer);
        }

        private void ShowLogin()
        {
            SceneManager.LoadScene(GlobalConstant.LOGIN_INDEX);
        }

    }

}