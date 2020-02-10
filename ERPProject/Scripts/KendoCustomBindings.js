//custom binding for value
kendo.data.binders.widget.comboboxValue = kendo.data.Binder.extend({
    init: function (widget, bindings, options) {
        //call the base constructor
        kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
        this.widget = widget;
        this._change = $.proxy(this.change, this);
        this.widget.bind("change", this._change);
    },
    change: function (e) {
        this.bindings["comboboxValue"].set(this.widget.value());

        //console.log(this.bindings["comboboxValue"].get());
        //var source = this.bindings["comboboxValue"].source,
        //    path = this.bindings["comboboxValue"].path;
        //updateObject(source, path, this.widget.value());
    },
    refresh: function () {
        var widget = this.widget,
            value = this.bindings["comboboxValue"].get();
        if (widget.dataSource.view()[0]) {
            widget.value(value);
        } else {
            widget.element.val(value);
        }
    },
    destroy: function () {
        this.widget.unbind("change", this._change);
    }
});

//custom binding for text
kendo.data.binders.widget.comboboxText = kendo.data.Binder.extend({
    init: function (widget, bindings, options) {
        //call the base constructor
        kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);

        this.widget = widget;
        this._change = $.proxy(this.change, this);
        this.widget.bind("change", this._change);
    },
    change: function () {
        this.bindings.comboboxText.set(this.widget.text());
    },
    refresh: function () {
        this.widget.input.val(this.bindings.comboboxText.get());
    },
    destroy: function () {
        this.widget.unbind("change", this._change);
    }
});
