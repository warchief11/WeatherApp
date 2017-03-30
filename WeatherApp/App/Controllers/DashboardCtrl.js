angular.module('WeatherApp')
    .controller('DashboardCtrl', DashboardCtrl);

DashboardCtrl.$inject = ['$scope', 'Weather'];

function DashboardCtrl($scope, Weather) {
    var vm = this;
    vm.country = "Australia";
   
    vm.getForecast = function () {
        Weather.getForecast(vm.city, vm.country).then(function (data) {
            vm.forecast = data;
        });
    };

    //vm.getWeatherItems = function (selectedWeather) {
    //    Weather.getWeatherItems(selectedWeather.Id).then(function (data) {
    //        vm.WeatherItems = data;
    //        vm.gridOptionsWeatherItems.data = data;         
    //    });
    //}

    vm.getLocations = function () {
        return Weather.getCities(vm.country).then(function (data) {
            vm.locations = data;
        });
    };

    vm.parseDate = function (time) {
        return new Date(time * 1000);
    };
    
    return vm;
};