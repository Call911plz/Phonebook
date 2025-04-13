
static class MenuEnums
{
    public enum Main { MANAGECONTACTS, MANAGECATEGORY, SENDEMAIL, EXIT }
    public enum Contact { ADDCONTACT, DELETECONTACT, UPDATECONTACT, READCONTACT, BACK }
    public enum Category { ADDCATEGORY, DELETECATEGORY, UPDATECATEGORY, READCATEGORY, BACK }
    public enum SendEmail { SENDEMAIL, SENDSMS, ADDUSERDATA, DELETEUSERDATA, UPDATEUSERDATA, BACK }
}

static class CarrierEmailDomains
{
    // If i were a less lazy man, I would probably put these to a json file and have
    // a function to read them.
    public static Dictionary<string, string> domains = new()
    {
        {"Alaska Communications", "msg.acsalaska.com"},
        {"AT&T Wireless", "txt.att.net"},
        {"Bell Mobility", "txt.bell.ca"},
        {"Boost Mobile", "myboostmobile.com"},
        {"Cricket", "mms.cricketwireless.net"},
        {"Freedom Mobile", "txt.freedommobile.ca"},
        {"Google Fi", "msg.fi.google.com"},
        {"Mint Mobile", "tmomail.net"},
        {"T-Mobile USA, Inc.", "tmomail.net"},
        {"Verizon", "vtext.com"},
        {"Virgin Mobile", "vmobl.com"},
        {"Xfinity Mobile", "vtext.com"},
    };
}