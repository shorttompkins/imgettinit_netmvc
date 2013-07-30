
(function () {
    var root = this;

    require.config({
        baseUrl: "/scripts/app/",
        paths: {
            underscore: '../lib/underscore.min',
            backbone: '../lib/backbone.min',
            'jquery.masonry': '../lib/masonry',
            'jquery.imagesLoaded': '../lib/imagesloaded',
            'jquery.simplemodal': '../lib/jquery.simplemodal.1.4.4.min',
            'json2':'../lib/json2'
        },
        shim: {
            underscore: { exports: '_' },
            backbone: { deps: ['underscore', 'jquery', 'json2'], exports: 'Backbone' },
            'jquery.masonry': { deps: ['jquery'], exports: 'masonry' },
            'jquery.imagesLoaded': { deps: ['jquery'], exports: 'imagesloaded' },
            'jquery.simplemodal': { deps: ['jquery'], exports: 'modal' }
        }    
    });

    //these are defined externally so they can be used in our view templates:
    define('jquery', [], function () { return root.jQuery; });
    define('moment', [], function () { return root.moment; });    

    require(['app'], function (app) {
        app.run();
    });
    
})();


