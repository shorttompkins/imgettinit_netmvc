define(['backbone', 'models/m_console'], function (Backbone, ConsoleModel) {
    var View = Backbone.View.extend({
        tagName: 'div',
        className: 'gettin-button-container',
        initialize: function () {
            var that = this;
            this.collection = new ConsoleModel.Collection(that.model.get('consoles'));
        },

        events: {
            'click a.gettin-button': 'showConsoleList'
        },

        render: function () {
            var that = this;
            var consoles = '';
            this.$el.html('<a href="#" class="gettin-button"><span style="float: right;">&#9660;</span>Gettin...</a><div class="consoles-list hidden"></div>');

            _.each(this.collection.models, function (c) {
                that.renderConsoleItem(c);
            });           

            return this;
        },
        renderConsoleItem: function (c) {
            var view = new consoleView({ model: c, gameid: this.model.get('gameId') });
            this.$el.find('div.consoles-list').append(view.render().el);
        },
        showConsoleList: function (e) {
            e.preventDefault();
            $('div.consoles-list').toggle();
        }
    });

    var consoleView = Backbone.View.extend({
        className: 'console-item',
        events: { 'click':'clickedConsole' },
        render: function () { this.$el.addClass('c' + this.model.get('consoleId')).html(this.model.get('title')); return this; },
        clickedConsole: function () {
            console.log('Youre gettin it for: ' + this.model.get('title'));
            var that = this;
            $.ajax({
                url: '/api/gettin',
                data: '{ gameid: ' + that.options.gameid + ', consoleid: ' + that.model.get('consoleId') + ' }',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (d) {
                    console.log("Result of gettin button ajax call: " + d.status);
                }
            });

            $('div.consoles-list').hide();
        }
    });

    return View;
});