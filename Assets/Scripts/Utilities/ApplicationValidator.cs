using CardGame.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Utilities
{
    public class ApplicationValidator
    {
        static public bool IsValidUser()
        {
            return !string.IsNullOrEmpty( SecurePlayerPrefs.GetString(GlobalConstant.KEY_TOKEN));
        }
    }
}
