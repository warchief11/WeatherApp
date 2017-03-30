(function () {

    var app = angular.module('orderApp', ['ui.router', 'ui.grid', 'ui.grid.selection', 'ui.grid.pagination']);

    app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
        $stateProvider
             .state("dashboard", {
                 url: "/",
                 templateUrl: 'App/templates/dashboard.html',
                 controller: 'DashboardCtrl as vm'
             })
             .state('about', {
                 url: '/about',
                 templateUrl: 'App/templates/about.html',
             });
    }]);
}());