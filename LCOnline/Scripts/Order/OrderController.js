orderModule.controller("orderController", function ($scope, $interval,orderService) {
   
    orderService.getOrders().then(function (orders) { $scope.orders = orders }, function ()
    { alert('error while fetching talks from server') })
  
  

    $scope.StatusColor = function (index) {
        var colorpallete;
        var orderDateTime = new Date($scope.orders[index].orderTime);
        var orderStatus = $scope.orders[index].status;
        var curDate = new Date();
        if (orderStatus == 'Delivered') {
            return 'blue';
        }
        if (curDate - orderDateTime > 300000) {
            colorpallete = 'red';
        } else {
            colorpallete = 'green';
        }
        return colorpallete;
    },

     $scope.IsPacked = function (index) {
         var orderStatus = $scope.orders[index].status;

         if (orderStatus == 'OrderPrepared' || orderStatus == 'OrderOut' || orderStatus == 'Delivered') {
             return 'checked';
         }
         
         return 'unchecked';
     },
     $scope.IsOut = function (index) {
         var orderStatus = $scope.orders[index].status;

         if (orderStatus == 'OrderOut' || orderStatus == 'Delivered') {
             return 'checked';
         }

         return 'unchecked';
     },
     $scope.IsDelivered = function (index) {
         var orderStatus = $scope.orders[index].status;

         if (orderStatus == 'Delivered') {
             return 'checked';
         }

         return 'unchecked';
     },

     $scope.updateOrder = function ($event, index) {

         //TODO : Do we need check to uncheck
         var gotChecked = false;
         var order = $scope.orders[index];
        
         if ($event.target.src.indexOf('unchecked.png') > -1) {
             $event.target.src = $event.target.src.replace('unchecked.png', 'checked.png');
             gotChecked = true;
         } else {
             $event.target.src = $event.target.src.replace('checked.png', 'unchecked.png');
             gotChecked = false;
         }
        // alert($event.target.id.replace(order.orderNo, ''));
         if (gotChecked) {
             switch ($event.target.id.replace(order.orderNo, '')) {
                 case "packedImg":
                     order.status = 'OrderPrepared';
                     break;
                 case "outImg":
                     order.status = 'OrderOut';
                     break;
                 case "deliveredImg":
                     order.status = 'Delivered';
                     break;
             }
         }

         orderService.updateOrder(order).then(function (orders) { $scope.orders = orders }, function ()
         { alert('error while fetching talks from server') })
     },

    $scope.RefreshOrders = function () {
        $interval(function () {          
            orderService.getOrders().then(function (orders) { $scope.orders = orders }, function ()
            { alert('error while fetching talks from server') })
        }, 5000);
    }
   $scope.RefreshOrders();
});

function UpdateOrderObject(element, order) {
    switch (element.replace(order.orderNo, '')) {
        case "packedImg":
            // Blah
            break;
        case "xxx.dev.yyy.com":
            // Blah
            break;
    }
}