define(['backbone', 'models/m_user', 'views/v_friends', 'views/v_gettinbutton'], function (Backbone, UserModel, FriendsView, GettinButtonView) {
    var View = Backbone.View.extend({
        tagName: 'div',
        id: "detailsView",
        className: 'hidden',
        template: $('#gameDetailsTemplate').html(),
        initialize: function () {
            //_.bindAll(this, "render");
            //this.model.bind("change", this.render);
        },
        render: function () {
            console.log("rendering game details");
            var that = this;
            var tmpl = _.template(this.template);
            this.$el.html(tmpl(this.model.toJSON()));

            //should we "cache" the details get on a game - or force it every time?
            //perhaps we just use this as a marker to hide/reveal details along with an ajax loader (resetting detailsLoaded back one the details have been displayed)
            if (this.model.get('detailsLoaded') === false) {
                this.loadDetails();
            } else {
                //use nested views to render each section individually:
                this.renderFriends(this.model.get('friends'));
                this.renderGettinButton(this.model);
                this.model.set('detailsLoaded', false);
                $('#gameDetailsLoader').slideUp('fast');
                $('#gameDetailsFull').slideDown('fast');
            }

            return this;
        },
        renderFriends: function (fr) {
            var view = new FriendsView({ collection: fr });
            this.$el.find('#divFriends').html(view.render().el);
        },
        renderGettinButton: function(g){
            var view = new GettinButtonView({ model: this.model });
            this.$el.find('#gettinButton').html(view.render().el);
        },
        loadDetails: function () {
            console.log("fetching game details");
            var friends = new UserModel.Collection();
            //**!!! - technically this whole area should be fetching the game details model - not friends
            var that = this;

            friends.fetch({
                success: function () {
                    that.model.set('friends', friends);
                    that.model.set('detailsLoaded', true);
                    that.render();
                }
            });

            return this;
        }
    });  

    return View;
});