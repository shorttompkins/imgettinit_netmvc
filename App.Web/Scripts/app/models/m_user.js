define(['config', 'backbone'], function (config, Backbone) {
    var User = Backbone.Model.extend({
        defaults: {
            username: '',
            avatar: ''            
        },
        url: config.apiRoot + 'friends'
    });
    var Users = Backbone.Collection.extend({
        model: User,
        url: config.apiRoot + 'friends'
    });

    return {
        Model: User,
        Collection: Users
    };
});