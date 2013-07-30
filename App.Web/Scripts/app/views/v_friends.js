define(['backbone', 'views/v_friend'], function (Backbone, FriendView) {
    var View = Backbone.View.extend({
        className: 'friendsList',
        initialize: function () {
            this.listenTo(this.collection, "reset", function () { console.log("Friend mode change event detected!"); });
        },
        render: function () {
            this.$el.html('');
            var that = this;

            _.each(this.collection.models, function (item) {
                that.renderFriend(item);
            }, this);

            return this;
        },

        renderFriend: function (item) {
            var view = new FriendView({ model: item });
            this.$el.append(view.render().el);
        }

    });

    return View;

});