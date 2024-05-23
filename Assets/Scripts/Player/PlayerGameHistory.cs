using CardGame.Main;
using CardGame.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Player
{
    [Serializable]
    public class PlayerGameHistory
    {
        public List<PlayerGameData> PlayerGameDataHistory;
        public PlayerGameHistory()
        {
            PlayerGameDataHistory = new List<PlayerGameData>();
        }

        public List<PlayerGameData> GetSavedHistory() 
        {
            string historyText = SecurePlayerPrefs.GetString(GlobalConstant.KEY_PLAYERDATAHISTORY);
            JsonUtility.FromJsonOverwrite(historyText, PlayerGameDataHistory);
            return PlayerGameDataHistory;
        }

        public void AddSavedHistory(PlayerGameData newGameEntry)
        {
            PlayerGameDataHistory = GetSavedHistory();
            PlayerGameDataHistory.Add(newGameEntry);

            SecurePlayerPrefs.SetString(GlobalConstant.KEY_PLAYERDATAHISTORY, JsonUtility.ToJson(PlayerGameDataHistory));
           
        }
    }
}
