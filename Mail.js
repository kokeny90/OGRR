//window.addEventListener("dragover", function (e) {
//    e = e || event;
//    e.preventDefault();
//}, false);
//window.addEventListener("drop", function (e) {
//    e = e || event;
//    e.preventDefault();
//}, false);
function call_me(params) {
    try {
        var theApp = new ActiveXObject("Outlook.Application")
        var theMailItem = theApp.CreateItem(0) // value 0 = MailItem
        //Bind the variables with the email
        var mySigline = theMailItem.HTMLBody;
        theMailItem.to = params[0];
        theMailItem.HTMLBody = params[1];
        theMailItem.Subject = params[2];
        theMailItem.cc = params[3];
        var mAts = theMailItem.Attachments;
        for (i = 4; i < params.length; i++) {
            mAts.Add(params[i]);
        }
        theMailItem.HTMLBody += mySigline;
        theMailItem.display();
    }
    catch (err) {
        alert(err.message);
    }
    //window.open("http://mc-logp01.emea.bosch.com/SGHU_LOG_52/order.aspx", "_self")
}