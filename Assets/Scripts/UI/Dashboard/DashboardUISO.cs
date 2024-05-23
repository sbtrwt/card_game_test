using CardGame.GameRoom;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.UI.Dashboard
{
    [CreateAssetMenu(fileName = "DashboardUIScriptableObject", menuName = "ScriptableObjects/DashboardUIScriptableObject")]

    public class DashboardUISO : ScriptableObject
    {
        public List<GameRoomSO> GameRoomsSO;
        public GameRoomButtonView GameRoomButtonViewPrefab;
    }
}
