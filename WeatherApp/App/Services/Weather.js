angular.module('WeatherApp')
       .service('Weather', Weather);

Weather.$inject = ['$http', '$q'];

function Weather($http, $q) {

    this.getForecast = function (city, country) {
        return $http.get('api/forecasts?city=' + city + "&country=" + country).then(function (response)
        {
           return response.data;
        })
    };

    this.getCities = function (country) {
        return $http.get('api/locations/?country=' + country).then(function (response) {
            return response.data;
        });
    };
};