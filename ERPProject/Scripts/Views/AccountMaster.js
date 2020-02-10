var script = "<script id='accountTemplate' type='text/x-kendo-template'> </script>",
    ViewModel = kendo.observable({
    account: {},
    detailsDataSource: [],
    //AccountdataSource: App.ComboDataSource("Sale/Combo/GetAccountName/", "accountCombo"),
        //GodowndataSource: App.ComboDataSource("Sale/Combo/GetGodowns/")

    NewSaveAccounDetail: function (e) {        
        console.log(ViewModel.get("account"));
        if (validator.validate()) {
            App.jsonSubmit("Sale/AccountMaster/Save/", ViewModel.get("account"),false , function (result) {
                if (result.WasSuccessful) {
                    debugger
                    App.MsgBox(result.Message, "Sale/AccountMaster/CreateAccount/", "Message", true);
                }
            });
            
        }
        

    }
});

function showAccountWindow(){
    accountDetailWindow = App.modelWindow("accountDetailWindow", "850px", "Account Master")
    var template = kendo.template($("#accountTemplate").html());
    accountDetailWindow.content(template);
    accountDetailWindow.center().open();

    ViewModel.set("account", accountdata);
    console.log(ViewModel.account)
    kendo.bind(accountDetailWindow.element, ViewModel.account);
    window.dlgValidator = $("#AccountDetailForm").kendoValidator().data("kendoValidator");
    
}


//App.AddNew("AccountDetailForm", showAccountWindow);


kendo.bind("#AccountDetailForm", ViewModel);
ViewModel.set("account", accountdata);
//console.log(ViewModel.account);
window.validator = $("#AccountDetailForm").kendoValidator().data("kendoValidator");
