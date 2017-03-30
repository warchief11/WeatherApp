angular.module('orderApp')
       .service('Order', Order);

Order.$inject = ['$http', '$q'];

function Order($http, $q) {

    this.getOrders = function () {
        return $http.get('api/orders').then(function (response)
        {
           return response.data;
        })
    };

    this.getOrderItems = function (orderID) {
        return $http.get('api/orders/' + orderID + '/orderItems').then(function (response) {
            return response.data;
        });
    };
};