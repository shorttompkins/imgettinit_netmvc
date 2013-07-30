define(['backbone', 'views/v_game'], function (Backbone, GameView) {
    var View = Backbone.View.extend({
        tagName: 'ul',
        id: 'games',

        initialize: function () {
            this.collection.fetch();
        },

        render: function () {
            this.$el.html('');
            var that = this;
            _.each(this.collection.models, function (item) {
                that.renderGame(item);
            }, this);

            return this;
        },

        renderGame: function (item) {
            var view = new GameView({ model: item });
            this.$el.append(view.render().el);
        }

        //need a way to handle loading only NEW items and not rerendering the ENTIRE list (want to append new items not redraw the whole thing)

    });

    return View;

});