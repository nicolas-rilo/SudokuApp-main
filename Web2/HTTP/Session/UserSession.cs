using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Es.Udc.DotNet.SudokuApp.Web.HTTP.Session
{
    public class UserSession
    {
        private long userProfileId;
        private String firstname;

        public long UserProfileId
        {
            get { return userProfileId; }
            set { userProfileId = value; }
        }

        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
    }
}