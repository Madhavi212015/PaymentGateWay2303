(function () {

    var app = angular.module('app', []);
    app.controller('paymentCtrl',
        ['$scope', '$http', function ($scope, $http) {
           
            $scope.submitForm = function () {
                if ($scope.paymentForm.$invalid) return false;

                console.log($scope.account);
                console.log($scope.amount);

                $http.post('/home/makePayment?accName=' + $scope.name + '&account=' + $scope.account + '&bsb=' + $scope.bsb + '&amount=' + $scope.amount).then(function (result) {
                    if (result.data != 'Failed') {
                        alert('Payment Successful'+ '\n' + 'Payment Receipt: ' + result.data);
                    }
                    return result;
                });
            }
        }]);

    app.directive('numbersOnly', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attr, ngModelCtrl) {
                function fromUser(text) {
                    if (text) {
                        var transformedInput = text.replace(/[^0-9]/g, '');

                        if (transformedInput !== text) {
                            ngModelCtrl.$setViewValue(transformedInput);
                            ngModelCtrl.$render();
                        }

                        return transformedInput;
                    }
                    return undefined;
                }
                ngModelCtrl.$parsers.push(fromUser);
            }
        };
    });

})();









