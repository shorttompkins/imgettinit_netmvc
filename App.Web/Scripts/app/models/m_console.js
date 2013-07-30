define(['config', 'backbone'], function (config, Backbone) {
    var Console = Backbone.Model.extend({
        url: config.apiRoot + 'consoles',
    });

    var Consoles = Backbone.Collection.extend({
        model: Console,
        url: config.apiRoot + 'consoles'
    });

    return {
        Model: Console,
        Collection: Consoles
    }
});