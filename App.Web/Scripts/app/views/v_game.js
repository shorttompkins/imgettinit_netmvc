define(['config', 'backbone', 'jquery.simplemodal', 'views/v_gamedetails'], function (config, Backbone, modal, DetailsView) {
    var View = Backbone.View.extend({
        tagName: 'li',
        template: $('#gameTemplate').html(),
        events: {
            'click':'showDetails'
        },
        render: function () {
            var tmpl = _.template(this.template);
            this.$el.html(tmpl(this.model.toJSON()));
            return this;
        },
        showDetails: function (e) {
            var detailsView = new DetailsView({ model: this.model });
            //$(e.currentTarget).after(detailsView.render().el);
            //findAndInsertDetails($(e.currentTarget), detailsView.render().el)
            $('#detailsView').remove();
            $('body').append(detailsView.render().el);
            $.modal.close();
            $('#detailsView').modal({ opacity: 85, overlayClose: true, escClose: true, autoResize: true });
        }
    });

    return View;

});