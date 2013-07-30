define(['backbone', 'models/m_console'], function (Backbone, ConsoleModel) {
    var c = new ConsoleModel.Collection();
    c.fetch();

    return {
        consoles: c
    }
});