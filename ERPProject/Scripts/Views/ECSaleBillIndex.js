$("#createButton").click(function () {
    window.location = _rootUrl + "Sale/Sale/Create";
});

$("#SaleDetail").kendoGrid({
    height: 600,
    selectable: true,
    scrollable: true,
    navigatable: true,
    resizable: true,
    sortable: true,
    filterable: true,
    groupable:true,

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
       }       
    ]
}); 



