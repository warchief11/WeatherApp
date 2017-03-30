angular.module('orderApp')
    .controller('DashboardCtrl', DashboardCtrl);

DashboardCtrl.$inject = ['$scope', 'Order'];

function DashboardCtrl($scope, Order) {
    var vm = this;

    var paginationOptions = {
        pageNumber: 1,
        pageSize: 5,
        sort: null
    };

    vm.gridOptions = {
        enableRowSelection: true,
        enableFullRowSelection: true,
        multiSelect: false,      
        paginationPageSizes: [5, 10, 20],
        paginationPageSize: 5,
        useExternalPagination: true,
        useExternalSorting: true,
        noUnselect : true,
        onRegisterApi : function(gridApi){
            gridApi.selection.on.rowSelectionChanged($scope, function (row) {                
                vm.getOrderItems(row.entity);
            });

            gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                paginationOptions.pageNumber = newPage;
                paginationOptions.pageSize = pageSize;
                getPage();
            });

            vm.gridApi = gridApi;
        },
        columnDefs : [
           { name: 'OrderId', field: 'Id' },
           { name: 'ClientId' },
           { name: 'ClientName' },
           { name: 'OrderDate' },
           { name: 'GST' },
           { name: 'Total' }
        ]
    };

    vm.gridOptionsOrderItems = {
        columnDefs : [
           { name: 'Id' },
           { name: 'ProductCode' },
           { name: 'Quantity' },
           { name: 'TotalPrice' }
        ],
        onRegisterApi: function (gridApi) {
            vm.gridApiOrderItems = gridApi;
        }
    };

    vm.getOrders = function () {
        Order.getOrders().then(function (data) {           
            vm.gridOptions.totalItems = data.length;

            var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
            vm.gridOptions.data = data.slice(firstRow, firstRow + paginationOptions.pageSize);           
        });
    };

    vm.getOrderItems = function (selectedOrder) {
        Order.getOrderItems(selectedOrder.Id).then(function (data) {
            vm.orderItems = data;
            vm.gridOptionsOrderItems.data = data;         
        });
    }

    vm.getOrders();
    return vm;
};