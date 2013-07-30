define(['config','backbone', 'models/m_user'], function (config,Backbone, User) {
    var Game = Backbone.Model.extend({
        idAttribute: 'gameId',
        url: config.apiRoot + 'games',
        defaults: {
            friends: new User.Collection(),
            userConsoleId: 0,
            detailsLoaded: false
        }
    });
    var Games = Backbone.Collection.extend({
        model: Game,
        url: config.apiRoot + 'games'        
    });

    return {
        Model: Game,
        Collection: Games
    };
});