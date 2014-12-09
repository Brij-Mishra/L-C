orderModule.factory("orderService", function ($http, $q) {
    return {
        getOrders: function () {
            // Get the deferred object
            var deferred = $q.defer();
            // Initiates the AJAX call
            $http({ method: 'GET', url: '/orderAdmin/GetOrders' }).success(deferred.resolve).error(deferred.reject);
            // Returns the promise - Contains result once request completes
            return deferred.promise;
        },
        //getSpeakers: function () {
        //    // Get the deferred object
        //    var deferred = $q.defer();
        //    // Initiates the AJAX call
        //    $http({ method: 'GET', url: '/events/GetSpeakerDetails' }).success(deferred.resolve).error(deferred.reject);
        //    // Returns the promise - Contains result once request completes
        //    return deferred.promise;
        //},
        updateOrder: function (order) {
            // Get the deferred object
            var deferred = $q.defer();
            // Initiates the AJAX call
            $http({ method: 'POST', url: '/orderAdmin/UpdateOrder', data: order }).success(deferred.resolve).error(deferred.reject);
            // Returns the promise - Contains result once request completes
            return deferred.promise;
        }
    }
});