(function ($) {
    var ENTER_KEY = 13;
    var APP_ROOT_URL = "http://10.137.12.43";

    //#region DATA:
    var assetsData = [
        { id: "1", title: "Improving Quality of Care While Increasing Patient Volume", atype: "videos", products: ["NextGen Ambulatory"], description: "Hear Tricia Salmo, RN discuss how NextGen® solutions have helped Southern Illinois Dermatology improve quality of care while increasing patient volume and revenue.", updatedDate: "1/18/2013", author: "Jim Hollis", featured: true, fileUrl: "http://video-js.zencoder.com/oceans-clip.mp4", fileSize: "98.6Mb", tags: ["ambulatory", "ehr", "improve"] },
        { id: "2", title: "NextGen Mobile Demonstration", atype: "demos", products: ["NextGen Mobile", "NextGen Ambulatory"], description: "See how the innovative new NextGen® Mobile securely places valuable information at your fingertips anytime, anywhere. Now you can provide fast, accurate, and convenient care for your patients.", updatedDate: "1/23/2013", author: "Jim Hollis", featured: false, fileUrl: "http://video-js.zencoder.com/oceans-clip.mp4", fileSize: "8.2Mb", tags: ["ehr", "dental", "kevin"] },
        { id: "3", title: "NextGen Patient Portal Demonstration", atype: "demos", products: ["NextGen Patient Portal", "NextGen Ambulatory"], description: "See how the patient-provider NextGen® Patient Portal promotes an interactive continuum of care between the patient and the practice, facilitating effective electronic communication and clinical data exchange.", updatedDate: "1/23/2013", author: "Jim Hollis", featured: false, fileUrl: "http://video-js.zencoder.com/oceans-clip.mp4", fileSize: "1.1Mb", tags: ["ehr", "james", "ambulatory"] },
        { id: "4", title: "NextPen Demonstration", atype: "demos", products: ["NextGen Ambulatory", "NextPen"], description: "Watch the seamless translation of handwritten data into structured electronic data by using NextPen®. Imagine the change in workflow when you no longer need to scan documents or transcribe information from patient forms.", updatedDate: "1/23/2013", author: "Jim Hollis", featured: true, fileUrl: "http://video-js.zencoder.com/oceans-clip.mp4", fileSize: "800kb", tags: ["jason", "dental", "ambulatory"] },
        { id: "5", title: "Accountable Care/Shared Savings Models White Paper", atype: "whitepapers", products: ["NextGen Ambulatory", "InSight Reporting"], description: "Download our whitepaper to understand why Healthcare Providers need to start preparing now.", updatedDate: "1/23/2013", author: "Jim Hollis", featured: true, fileUrl: "http://www.nextgen.com/pdf/WP_ACO_2011.pdf", fileSize: "800kb", tags: ["jason", "dental", "ambulatory"] }
    ];
    var atypes = [
        { title: "videos", iconUrl: APP_ROOT_URL + "/cdn/salesforceapp/img/icon_videos.jpg" },
        { title: "demos", iconUrl: APP_ROOT_URL + "/cdn/salesforceapp/img/icon_demos.jpg" },
        { title: "brochures", iconUrl: APP_ROOT_URL + "/cdn/salesforceapp/img/icon_brochures.jpg" },
        { title: "webinars", iconUrl: APP_ROOT_URL + "/cdn/salesforceapp/img/icon_webinars.jpg" },
        { title: "whitepapers", iconUrl: APP_ROOT_URL + "/cdn/salesforceapp/img/icon_whitepapers.jpg" }
    ];
    var products = [
        { title: "InSight Reporting", icon: "", id: 1, selected: false },
        { title: "NextGen Ambulatory", icon: "", id: 2, selected: false },
        { title: "NextGen Dashboard", icon: "", id: 3, selected: false },
        { title: "NextGen Document Management", icon: "", id: 4, selected: false },
        { title: "NextGen EDR", icon: "", id: 5, selected: false },
        { title: "NextGen Emergency Department Solution", icon: "", id: 6, selected: false },
        { title: "NextGen Enterprise Scheduling", icon: "", id: 7, selected: false },
        { title: "NextGen ePrescribing", icon: "", id: 8, selected: false },
        { title: "NextGen Health Information Exchange", icon: "", id: 9, selected: false },
        { title: "NextGen Health Quality Measures", icon: "", id: 10, selected: false },
        { title: "NextGen Inpatient Clinicals", icon: "", id: 11, selected: false },
        { title: "NextGen Inpatient Financials", icon: "", id: 12, selected: false },
        { title: "NextGen Mobile", icon: "", id: 13, selected: false },
        { title: "NextGen Patient Portal", icon: "", id: 14, selected: false },
        { title: "NextGen Population Health Management", icon: "", id: 15, selected: false },
        { title: "NextGen Practice Management", icon: "", id: 16, selected: false },
        { title: "NextGen Surgical Management", icon: "", id: 17, selected: false },
        { title: "NextPen", icon: "", id: 18, selected: false }
    ]
    //#endregion

    //#region MODELS / COLLECTIONS:
    var Asset = Backbone.Model.extend();
    var Assets = Backbone.Collection.extend({ model: Asset });
    var Product = Backbone.Model.extend();
    var Products = Backbone.Collection.extend({ model: Product });
    var AType = Backbone.Model.extend();
    var ATypes = Backbone.Collection.extend({ model: AType });

    //global collection of main assets list
    var assets = new Assets(assetsData);
    //#endregion

    //#region VIEWS:
    var ProductView = Backbone.View.extend({
        tagName: 'li',
        template: $('#productTemplate').html(),
        events: {
            'click': 'showByProduct'
        },

        render: function () {
            var tmpl = _.template(this.template);
            this.$el.html(tmpl(this.model.toJSON()));

            return this;
        },

        showByProduct: function () {
            appRouter.navigate("products/" + this.model.get('id'), true);
        }
    });
    var ProductsView = Backbone.View.extend({
        tagName: 'ul',
        id: 'productsList',
        template: $('#productsListTemplate').html(),

        initialize: function () {
            this.collection = new Products(products);
        },

        render: function () {
            this.$el.html('');
            var that = this;
            _.each(this.collection.models, function (item) { that.renderAsset(item); }, this);
            return this;
        },

        renderAsset: function (item) {
            var view = new ProductView({ model: item });
            this.$el.append(view.render().el);
        },

        getProduct: function (p) {
            return this.collection.get(p);
        }
    });

    var AssetView = Backbone.View.extend({
        tagName: "li",
        className: "assetBrief",
        template: $('#assetDetailsTemplate').html(),
        initialize: function () {
            _.bindAll(this, "render");
            this.model.bind("change", this.render);
        },
        events: {
            'click': 'showDetails'
        },
        render: function () {
            var tmpl = _.template(this.template);
            this.$el.html(tmpl(this.model.toJSON()));

            return this;
        },
        showDetails: function () {
            appRouter.navigate(Backbone.history.fragment + "/" + this.model.get('id'), true);
        },
        getAssetTitle: function () {
            return this.model.get('title');
        }

    });
    var AssetsView = Backbone.View.extend({
        tagName: 'ul',
        id: 'assetBriefs',

        initialize: function () {
            this.collection = assets;
            return this;
        },

        hasResults: false,

        render: function () {
            this.hasResults = false;

            this.$el.html('');
            var that = this;
            _.each(this.collection.models, function (item) {
                that.renderAsset(item);
            }, this);

            if (!this.hasResults) {
                this.$el.append('<li class="assetBrief">No records found.</li>');
            }
            return this;
        },

        renderAsset: function (item) {
            var view = new AssetView({ model: item });
            this.$el.append(view.render().el);
            this.hasResults = true;
        },

        filterAssets: function (prod, atype) {
            var newCollection = this.collection.where({ "atype": atype }).filter(function (item) {
                return _.indexOf(item.attributes.products, new Products(products).get(prod).get('title')) > -1;
            });

            this.collection = new Assets(newCollection);
            return this;
        },
        searchAssets: function (searchStr) {
            var newCollection = this.collection.filter(function (item) {
                return _.indexOf(item.attributes.tags, searchStr.toLowerCase()) > -1;
            });

            this.collection = new Assets(newCollection);
            return this;
        },
        getAsset: function (asset) {
            this.initialize();
            return this.collection.get(asset);
        }

    });

    var ATypeView = Backbone.View.extend({
        tagName: 'li',
        className: 'atypeLink',
        template: $('#atypeTemplate').html(),
        events: {
            'click': 'showAssetsByAType'
        },

        render: function () {
            var tmpl = _.template(this.template);
            this.$el.html(tmpl(this.model.toJSON()));

            return this;
        },

        showAssetsByAType: function () {
            appRouter.navigate(Backbone.history.fragment + "/" + this.model.get('title'), true);
        }
    });
    var ATypesView = Backbone.View.extend({
        tagName: 'ul',
        className: 'atypesList',
        initialize: function () {
            this.collection = new ATypes(atypes);
        },

        render: function () {
            this.$el.html('');
            var that = this;
            _.each(this.collection.models, function (item) {
                that.renderItem(item);
            }, this);

            return this;
        },
        renderItem: function (item) {
            var view = new ATypeView({ model: item });
            this.$el.append(view.render().el);
        }
    });

    var AssetDetailsView = Backbone.View.extend({
        tagName: 'div',
        id: "assetDetails",
        template: $('#assetDetailsFullTemplate').html(),
        initialize: function () {
            _.bindAll(this, "render");
            this.model.bind("change", this.render);
        },

        render: function () {
            var tmpl = _.template(this.template);
            this.$el.html(tmpl(this.model.toJSON()));

            return this;
        }
    });

    var BreadCrumbView = Backbone.View.extend({
        tagName: 'section',
        id: 'breadcrumbs',
        template: $('#breadcrumbsTemplate').html(),

        render: function () {
            var tmpl = _.template(this.template);
            this.$el.html(tmpl(this.model));

            return this;
        }

    });

    var SearchBoxView = Backbone.View.extend({
        tagName: 'input',
        id: 'searchbox',
        placeholder: 'Search...',

        events: {
            'keypress': 'performSearch'
        },

        render: function () {
            this.$el.attr('placeholder', this.placeholder);
            return this;
        },

        performSearch: function (e) {
            if (e.charCode === ENTER_KEY) {
                appRouter.navigate("search/" + this.$el.val(), true);
            }
        }

    });
    //#endregion

    //#region ROUTER:
    var AppRouter = Backbone.Router.extend({
        initialize: function () {
            this.productsView = new ProductsView();
            this.assetsView = new AssetsView();
            this.search = new SearchBoxView();
            $('header').append(this.search.render().el);
        },
        routes: {
            "products/": "showProducts",
            "products/:product": "showByProduct",
            "products/:product/:atype": "showByProductAtype",
            "products/:product/:atype/:asset": "showAssetDetails",
            "search/:searchstr/:asset": "showAssetDetailsFromSearch",
            "search/:searchstr": "showSearchResults",

            "": "showProducts"
        },

        showProducts: function () {
            this.search.$el.val('');
            $('#app').html(this.productsView.render().el);
            $('#app').append('<div class="clear"></div>');
        },
        showByProduct: function (prod) {
            var productView = new ProductView({ model: this.productsView.getProduct(prod) });

            var atypes = new ATypesView();
            atypes.productTitle = this.productsView.getProduct(prod).get('title');

            $('#app').html(atypes.render().el);
            $('#app').append('<div class="clear"></div>');
            $('#app').prepend(new BreadCrumbView({ model: { productTitle: this.productsView.getProduct(prod).get('id'), atypeTitle: '' } }).render().el);
        },
        showByProductAtype: function (prod, atype) {
            this.assetsView.initialize().filterAssets(prod, atype);
            this.assetsView.productTitle = this.productsView.getProduct(prod).get('title');
            this.assetsView.atypeTitle = atype;
            $('#app').html(this.assetsView.render().el);
            $('#app').prepend(new BreadCrumbView({ model: { productTitle: this.productsView.getProduct(prod).get('id'), atypeTitle: atype } }).render().el);
        },
        showAssetDetails: function (prod, atype, asset) {
            var adv = new AssetDetailsView({ model: this.assetsView.getAsset(asset) });

            $('#app').html(adv.render().el);
            $('#app').prepend(new BreadCrumbView({ model: { productTitle: this.productsView.getProduct(prod).get('id'), atypeTitle: atype, assetTitle: adv.model.get('title') } }).render().el);
        },
        showAssetDetailsFromSearch: function (searchstr, asset) {
            var adv = new AssetDetailsView({ model: this.assetsView.getAsset(asset) });

            $('#app').html(adv.render().el);
            $('#app').prepend(new BreadCrumbView({ model: { assetTitle: adv.model.get('title') } }).render().el);
        },
        showSearchResults: function (searchstr) {
            var results = new AssetsView();
            results.searchAssets(this.search.$el.val());

            $('#app').html(results.render().el);

            $('#app').prepend(new BreadCrumbView({ model: { assetTitle: 'Search Results for: "' + this.search.$el.val() + '"' } }).render().el);
        }
    });
    //#endregion

    //boot up the app
    var appRouter = new AppRouter();
    Backbone.history.start();


    /*
        //for testing model binding
        $("#aTest").on('click', function (e) { e.preventDefault(); assets.get('1').set('title', 'This is a new title now!'); });
    */
})(jQuery);