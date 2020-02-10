/// <reference path="../jquery-1.7.2.js" />
App = {};
var voucherDetailDataSource;
var myWindow;
var IsGridShowing = true;


App.BindDateFormat = function () {
    $(".INmask").each(function () {
        $(this).mask("99/99/9999", { placeholder: " " });
    });
}

App.BindDateFormat();

App.init = function () {
    $("#Navigation").css("opacity", 1);
    // Bind Date format validation always true 

    jQuery.validator.methods["date"] = function (value, element) {
        if (value.trim().length == 10)
            return true;
        else {
            if (element.hasAttribute("data-val-required"))
                return false;
            else
                return true;
        }
    }
};


App.ComboDataSource = function (url, combo, createUrl) {
    var crudServiceBaseUrl = _rootUrl;
    var dataSource = new kendo.data.DataSource({
        batch: true,
        transport: {
            read: {
                url: crudServiceBaseUrl + url,
                dataType: "json"
            },
            create: {
                url: crudServiceBaseUrl + createUrl,
                dataType: "json"
            },
            parameterMap: function (options, operation) {
                if (operation !== "read" && options.models) {
                    return { models: kendo.stringify(options.models) };
                }
            }
        },
        schema: {
            model: {
                id: "ID",
                fields: {
                    ID: { type: "number" },
                    Value: { type: "string" }
                }
            }
        }
    });


    $("#" + combo).kendoComboBox({
        filter: "startswith",
        dataTextField: "Value",
        dataValueField: "ID",
        dataSource: dataSource,
        noDataTemplate: $("#noDataTemplate").html()
    });
    return dataSource;
}


App.jsonSubmit = function (url, dt, IsPreviewVoucher, theFunction) {
    var $waiting = $('<div id="waiting" ><div class="k-loading-image"></div></div>'); $('body').append($waiting);
    $.ajax({
        url: _rootUrl + url,
        type: "POST",
        data: JSON.stringify({ model: dt, IsPreviewVoucher: IsPreviewVoucher }),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            if (result.WasSuccessful) {
                console.log(result);
                if (typeof theFunction == "function") theFunction(result);

            }
            else {
                if (typeof theFunction == "function") theFunction(result);
            }
            // console.log(result);
        },
        complete: function () {
            //isSubmitting = false;

            $("#waiting").remove();
        }

    });
}

App.VoucherGrid = function (vouhcerdetail) {
    voucherDetailDataSource = new kendo.data.DataSource({

        transport: {
            read: function (option) {
                option.success(vouhcerdetail);
            }
        },
        schema: {
            model: {
                fields: {
                    AccountID: { type: "number" },
                    AccountName: { type: "string" },
                    Debit: { type: "number" },
                    Credit: { type: "number" }
                }
            }
        },
        aggregate: [
            { field: "Debit", aggregate: "sum" },
            { field: "Credit", aggregate: "sum" },

        ]
    });
    return voucherDetailDataSource;
}

App.VoucherGridDisplay = function (VoucherGrid) {
    $("#" + VoucherGrid).kendoGrid({
        height: 250,
        width: 100,
        selectable: false,
        scrollable: true,
        navigatable: false,
        resizable: true,
        sortable: true,
        columns: [
            { field: "AccountID", title: "AccountID", hidden: true, width: 80 },
            { field: "AccountName", title: "Account Name", width: 60 },
            {
                field: "Debit", title: "Debit", format: "{0:n2}", width: 20,
                headerAttributes: { style: "text-align: right;" },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div class='ralign'># if (data.Debit) { # #=kendo.toString(Debit.sum, 'n2')# # } #</div>"
            },
            {
                field: "Credit", title: "Credit", format: "{0:n2}", width: 20,
                headerAttributes: { style: "text-align: right;" },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div class='ralign'># if (data.Credit) { # #=kendo.toString(Credit.sum, 'n2')# # } #</div>"
            }
        ]
    });
}

App.MsgBox = function (message, url, titles, truevalue) {
    var images = { SaveImage: "'/Images/SaveIcon.png'", ErrorImage: "'/Images/Erroricon.png'" };
    var setimage = truevalue == true ? images.SaveImage : images.ErrorImage;
    myWindow = $("<div id='window'>" + "<p> <img src=" + setimage + " align='middle'>" + message + "</p>" + "<a id='OkButton' class='k-button' href='#a'>Ok</a>" + "</div>");
    //var image = $("");

    //var myWindow = $("#window");
    myWindow.kendoWindow({
        width: "300px",
        title: titles,
        visible: false,
        modal: true,
        resizable: false,
        actions: [
            "Close"
        ],
        close: onClose,
    }).data("kendoWindow").center().open();
    $(myWindow).find("p").css({ "margin-left": "50px", "font-weight": "bold" });
    $(myWindow).find("img").css("padding-bottom", "10px");
    var dialog = myWindow.data("kendoWindow");
    function onClose(e) {
        e.preventDefault();
        $("#OkButton").trigger("click");

    }
    $(myWindow).find('#OkButton').css("margin-left", "122px").click(function (e) {
        //    e.stopPropagation();
        if (url !== null) {
            window.location = _rootUrl + url;
        }
        else {

            dialog.destroy();
        }
    });

}
App.modelWindow = function (id, width, title) {
    var myWindow = $("<div class='App' id = " + id + "></div>")
    var kendoWindow = myWindow.data("kendoWindow")
    if (kendoWindow === undefined) {
        kendoWindow = myWindow.kendoWindow({
            width: width,
            title: title,
            modal: true,
            visible: false,
            actions: ["Close"],
            deactivate: function () {
                this.destroy();
            }

            //close: onClose
        }).data("kendoWindow");
    }
    else {
        myWindow.empty();
    }
    return kendoWindow;
}
