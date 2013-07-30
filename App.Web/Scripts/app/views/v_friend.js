define(['backbone'], function (Backbone) {
    var View = Backbone.View.extend({
        tagName: 'img',
        className: 'boxfriend',
        initialize: function () {
            this.listenTo(this.model, "reset", function () { console.log("Friend mode change event detected!"); });
            
        },
        events: {
            'click': 'showDetails'
        },
        render: function () {
            this.$el.attr({ 'src': this.model.get('avatar') });
            this.$el.html(this.el);

            return this;
        },
        showDetails: function () {
            console.log("you clicked on friend: " + this.model.get('username'));
        }

    });

    return View;
});