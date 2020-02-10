using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Utilities
{
    public  class ConfirmationMessages
    {
        public static ConfirmationMessages CreateSuccessConfirmation(string message) 
        {
            ConfirmationMessages confirmation = new ConfirmationMessages();
            confirmation.WasSuccessful = true;
            confirmation.Message = message;
            confirmation.Warning = false;
            return confirmation;
        }


        public bool WasSuccessful { get; private set; }
        public bool Warning { get; private set; }
        public string Message { get; set; }
        public object Value { get; set; }
        public Dictionary<string, string> Errors { get; set; }
    }
}