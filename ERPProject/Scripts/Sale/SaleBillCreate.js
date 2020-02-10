var saleDetailDatasource,

ViewModel = kendo.observable({
    sale: {},
    detailsDataSource: [],
    detailVoucherGrid:[],
    AccountdataSource: App.ComboDataSource("Sale/Combo/GetAccountName/", "accountCombo"),
    GodowndataSource: App.ComboDataSource("Sale/Combo/GetGodowns/"),
    save: function (e) {        
        var sales = this.get("sale");
        sales.PartyAccountId = $("#accountCombo").data('kendoComboBox').value();
        sales.SaleBillDetails = this.get("detailsDataSource")._data;           

        if ($('#saleDetailGrid').data("kendoGrid").dataSource.total() > 0) {
            if (validator.validate()) {
                if (e == undefined) {
                    console.log("true");
                    App.jsonSubmit("Sale/Sale/Save/", sales, true, function (result) {
                        ViewModel.set("detailVoucherGrid", App.VoucherGrid(result));
                        console.log(result);
                    });
                }
                else {
                    App.jsonSubmit("Sale/Sale/Save/", sales, false, function (result) {
                        if (result.WasSuccessful) {
                            App.MsgBox(result.Message, "Sale/Sale/Index", "Message", true);
                            //window.location = _rootUrl + "Sale/Sale/Index";
                        }
                    });
                }
               
            }        
        }
        else {
            App.MsgBox("Please add details first!!", null, "Error", false);
        }       
        //
    }
});

//App.ComboDataSource("Sale/Combo/GetAccountName/", "ERPCombo")
console.log(ViewModel.get("AccountdataSource"));

var DetailViewModel = kendo.observable({
    ItemDataSource: App.ComboDataSource("Sale/Combo/GetItems/"),
    TaxdataSource: App.ComboDataSource("Sale/Combo/GetTaxClass/"),
    PackingDataSource: App.ComboDataSource("Sale/Combo/GetPackingSize/"),
    detail: {},


    saveDetail: function (e) {        
        if (validator.validate()) {
            saleDetailDatasource.sync();
            saleDetailWindow.close();            
        }
    },

    NewsaveDetail: function (e) {
        updateDetaill(e);
    },

    cancelDetail: function (e) {
        saleDetailDatasource.cancelChanges(e.data);
        saleDetailWindow.close();
    },
    CalculateQty: function (e) {        
        CalcQty();
    },
    CalculateQTy: function (e) {
        CalcQty();
        CalculateTaxableAmount();
    },
    CalculateTaxableAmt: function (e) {
        CalculateTaxableAmount();
    },
    CalculateTax: function (e) {
        calculateTaxAmount();
    }
});
function CalcQty() {
    try{
        let model, packingSize;
        packingSize = $("#PackingCombo").data('kendoComboBox').dataItem();
        if (packingSize.PackingSizeCapacity !== undefined) {        
            model = DetailViewModel.get("detail");
            // console.log(packingSize.PackingSizeCapacity);
            DetailViewModel.set("detail.Quantity", ((model.Bags * packingSize.PackingSizeCapacity) / 100));
        }
    }
    catch (e) {

    }    
}

//function CalculateTotalAmt() {
//    debugger
//    var data = ViewModel.get("detailsDataSource")._data;
//    var totalAmount = data.TotalAmount;
//    ViewModel.set("sale.TotalAmount", totalAmount);
//}

function CalculateTaxableAmount() {
    try {
        var model;
        model = DetailViewModel.get("detail");
        DetailViewModel.set("detail.TaxableAmount", (model.Rate * model.Quantity));
    }
    catch (e) {

    }   
}
function calculateTaxAmount() {
    try{
        var model, taxRate;
        taxRate = $("#TaxCombo").data('kendoComboBox').dataItem();
        model = DetailViewModel.get("detail");
        DetailViewModel.set("detail.TaxAmount", (model.TaxableAmount * taxRate.TaxPer) / 100);
        if (model.TaxName.startsWith("GST")) {
            DetailViewModel.set("detail.CGSTAmount", (model.TaxAmount / 2))
            DetailViewModel.set("detail.SGSTAmount", (model.TaxAmount / 2))
            DetailViewModel.set("detail.IGSTAmount", 0)
        }
        else {
            DetailViewModel.set("detail.CGSTAmount", 0)
            DetailViewModel.set("detail.SGSTAmount", 0)
            DetailViewModel.set("detail.IGSTAmount", model.TaxAmount)
        }
        DetailViewModel.set("detail.TotalAmount", (model.TaxableAmount + model.TaxAmount));
        ViewModel.set("sale.TotalAmount", saleDetailDatasource.aggregates().TotalAmount.sum);

    }
    catch (e) {

    }  
}
//$(document).ready(function () {
//    var crudServiceBaseUrl = _rootUrl;
//    var dataSource = new kendo.data.DataSource({
//        batch: true,
//        transport: {
//            read: {
//                url: crudServiceBaseUrl + "Sale/Combo/GetAccountName/",
//                dataType: "json"
//            }
//            //create: {
//            //    url: crudServiceBaseUrl + "Sale/Combo/GetAccountName/",
//            //    dataType: "json"
//            //},
//            //parameterMap: function (options, operation) {
//            //    if (operation !== "read" && options.models) {
//            //        return { models: kendo.stringify(options.models) };
//            //    }
//            //}
//        },
//        schema: {
//            model: {
//                id: "ID",
//                fields: {
//                    ID: { type: "number" },
//                    Value: { type: "string" }
//                }
//            }
//        }
//    });


//    console.log(dataSource);

//    $("#products").kendoComboBox({
//        filter: "startswith",
//        dataTextField: "Value",
//        dataValueField: "ID",
//        dataSource: dataSource,
//        noDataTemplate: $("#noDataTemplate").html()
//    });
//});



var createDetailDataSource = function (details) {
    
    details.map(function (o) { o["Guid"] = o.Id; });
    saleDetailDatasource = new kendo.data.DataSource({
        
        transport: {
            read: function (option) {
                option.success(details);
            },
            create: function (option) {
                var num = saleDetailDatasource.aggregates().Guid.max + 1;
                option.data.id = num;
                option.data.Guid = num;
                option.success(option.data);
            },
            update: function (option) {
                option.success(option.data);
            },
            destroy: function (option) {
                option.success(option.data);
            }

        },
        schema: {
            model: {
                id: "Guid",
                fields: {
                    Id: { type: "number" },
                    ItemId: { type: "number" },
                    ItemName: { type: "string" },
                    Description: { type: "string" },
                    TaxName: { type: "string" },
                    Bags: { type: "number", validation: { min: 0, required: true } },
                    PackingSizeId: { type: "number" },
                    PackingSize: {type: "string"},
                    Quantity: { type: "number", validation: { min: 0, required: true } },
                    TaxableAmount: { type: "number", validation: { min: 0, required: true } },
                    CGSTAmount: { type: "number", validation: { min: 0, required: true } },
                    SGSTAmount: { type: "number", validation: { min: 0, required: true } },
                    IGSTAmount: { type: "number", validation: { min: 0, required: true } },
                    TaxAmount:  { type: "number", validation: { min: 0, required: true } },//TotalAmount
                    TotalAmount: { type: "number", validation: { min: 0, required: true } }
                }
            }
        },
        aggregate: [
            { field: "Guid", aggregate: "max" },
            { field: "CGSTAmount", aggregate: "sum" },
            { field: "SGSTAmount", aggregate: "sum" },
            { field: "IGSTAmount", aggregate: "sum" },
            { field: "TotalAmount", aggregate: "sum" },
            { field: "Quantity", aggregate: "sum" },
            { field: "TaxableAmount", aggregate: "sum" },
            { field: "Bags", aggregate: "sum" },
        ]
    });
    console.log(details);
    return saleDetailDatasource;
};

function addNew() {
    //window.location = _rootUrl + "Sale/Sale/CreateAccount"; 
    //$("#AccountDetailForm").unwrap(script);
    //$("#AccountDetailForm").wrap(script);

    window.location = _rootUrl + "Sale/AccountMaster/CreateAccount";
}

$("#saleDetailGrid").kendoGrid({
    height: 450,
    selectable: true,
    scrollable: true,
    navigatable: true,
    resizable: true,
    sortable: true,

    columns: [
        { field: "Id", title: "Id", hidden: true, width: 80 },
        { field: "ItemName", title: "Item Name", width: 100 },
        { field: "Description", title: "Description", width: 100 },
        { field: "TaxName", title: "Tax Class", width: 150 },
        {
            field: "Bags", title: "Bags", format: "{0:n2}", width: 80,
            headerAttributes: { style: "text-align: right;" },
            attributes: { style: "text-align: right;" },
            footerTemplate: "<div class='ralign'># if (data.Bags) { # #=kendo.toString(Bags.sum, 'n2')# # } #</div>"
        },
            {
                field: "PackingSize", title: "Packing Size", width: 150,
                headerAttributes: { style: "text-align: right;" }
            }
        ,
        {
            field: "Rate", title: "Rate", format: "{0:n2}", width: 80,
            headerAttributes: { style: "text-align: right;" },
            attributes: { style: "text-align: right;" }
        },
        {
            field: "Quantity", title: "Quantity", format: "{0:n2}", width: 80,
            headerAttributes: { style: "text-align: right;" },
            attributes: { style: "text-align: right;" },
            footerTemplate: "<div class='ralign'># if (data.Quantity) { # #=kendo.toString(Quantity.sum, 'n2')# # } #</div>"
        },
        {
            field: "TaxableAmount", title: "Taxable Amount", format: "{0:n2}", width: 100,
            headerAttributes: { style: "text-align: right;" },
            attributes: { style: "text-align: right;" },
            footerTemplate: "<div class='ralign'># if (data.TaxableAmount) { # #=kendo.toString(TaxableAmount.sum, 'n2')# # } #</div>"

        },
        {
            field: "CGSTAmount", title: "CGST", format: "{0:n2}", width: 80,
            headerAttributes: { style: "text-align: right;" },
            attributes: { style: "text-align: right;" },
            footerTemplate: "<div class='ralign'># if (data.CGSTAmount) { # #=kendo.toString(CGSTAmount.sum, 'n2')# # } #</div>"
        },
        {
            field: "SGSTAmount", title: "SGST", format: "{0:n2}", width: 80,
            headerAttributes: { style: "text-align: right;" },
            attributes: { style: "text-align: right;" },
            footerTemplate: "<div class='ralign'># if (data.SGSTAmount) { # #=kendo.toString(SGSTAmount.sum, 'n2')# # } #</div>"
        },
        {
            field: "IGSTAmount", title: "IGST", format: "{0:n2}", width: 80,
            headerAttributes: { style: "text-align: right;" },
            attributes: { style: "text-align: right;" },
            footerTemplate: "<div class='ralign'># if (data.IGSTAmount) { # #=kendo.toString(IGSTAmount.sum, 'n2')# # } #</div>"
        },
        {
            field: "TotalAmount", title: "Total Amount", format: "{0:n2}", width: 100,
            headerAttributes: { style: "text-align: right;" },
            attributes: { style: "text-align: right;" },
            footerTemplate: "<div class='ralign'># if (data.TotalAmount) { # #=kendo.toString(TotalAmount.sum, 'n2')# # } #</div>"
        },
        {
            command: [{ text: "Edit", click: editDetail },
                { text: "Delete", click: deleteDetail }], title: " ", width: "120px"
        }



    ],
    toolbar: [{ name: "Add", text: "Add Detail" }]
});

function editDetail(e) {
    var model = this.dataItem($(e.currentTarget).closest("tr"));
    showModel(model);
}

//App.modelWindow()

function deleteDetail(e) {
    var model = this.dataItem($(e.currentTarget).closest("tr"));
    saleDetailDatasource.remove(model);
    saleDetailDatasource.sync();
}

$(".k-grid-Add", "#saleDetailGrid").bind('click', function () {    
    var model = saleDetailDatasource.add({});
    console.log(model);
    showModel(model);

});

function showModel(model) {
    
    saleDetailWindow = App.modelWindow("saleDetailWindow", "750px", "Sale Bill Detail")
    var template = kendo.template($("#createTemplate").html());
    saleDetailWindow.content(template);
    saleDetailWindow.center().open();

    DetailViewModel.set("detail", model);

    kendo.bind(saleDetailWindow.element, DetailViewModel);

    window.dlgValidator = $("#saleDetailForm").kendoValidator().data("kendoValidator");

}

$(window).load(function () {    
    // Handler for .load() called.
    $("#VoucherGrid").hide();
});

App.VoucherGridDisplay("VoucherGrid");


function PreviewVoucher() {
    if ($('#saleDetailGrid').data("kendoGrid").dataSource.total() > 0) {
        if (IsGridShowing) {
            $("#saleDetailGrid").hide();
            IsGridShowing = false;
            $("#VoucherGrid").show();
            $("#PreViewVoucherClick").val("Hide Voucher");
            $(ViewModel).trigger("save");
        }
        else {
            $("#saleDetailGrid").show();
            IsGridShowing = true;
            $("#VoucherGrid").hide();
            $("#PreViewVoucherClick").val("Preview Voucher");
        }
    }
    else {
        App.MsgBox("Please add details first!!", null, "Error", false);
    }
}

function updateDetaill(e) {
    
    var grid = $("#saleDetailGrid").data("kendoGrid");

    saleDetailDatasource.sync();
    DetailViewModel.set("detail", saleDetailDatasource.add({}));
    

}


kendo.bind("#saleform", ViewModel);
ViewModel.set("sale", saledata);
console.log(saledata.SaleBillDetailViewModel);
ViewModel.set("detailsDataSource", createDetailDataSource(saledata.SaleBillDetails));
window.validator = $("#saleform").kendoValidator().data("kendoValidator");


