define(['backbone', 'models/m_game', 'views/v_games', 'views/v_game', 'jquery.masonry', 'jquery.imagesLoaded'], function (Backbone, Game, GamesView, GameView, masonry, imagesloaded) {
    var run = function () {
        bootBackboneRouter();
    };

    var bootBackboneRouter = function () {
        var AppRouter = Backbone.Router.extend({
            initialize: function () {
                this.games = new Game.Collection();
            },
            routes: {
                "": "main",
                "games/:gameid":"gameDetails"
            },

            main: function () {
                var games = new Game.Collection();
                var view = new GamesView({ collection: games });

                games.fetch({
                    //sample search parameters:
                    //data: {page: 2, searchstr: 'some query'},
                    success: function () {
                        $('#app').html(view.render().el);

                            $('#app ul').imagesLoaded(function () {
                                $('#app ul').masonry({
                                    // options
                                    itemSelector: 'li',
                                    isFitWidth: true,
                                    isAnimated: true,
                                    columnWidth: 250
                                });
                            });
                        }
                    });
                
            }
        });

        //boot up the app:
        var appRouter = new AppRouter();
        Backbone.history.start();
    }

    return {
        run: run
    };
});
