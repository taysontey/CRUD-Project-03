var myApp = angular.module('myApp', []);

myApp.controller('timeCtrl', function ($scope, $http) {

    $scope.msg = "";
    $scope.times = "";

    $http.get("/Time/Consultar")
    .success(function (lista) {
        $scope.times = lista;
    })
    .error(function (msg) {
        $scope.msg = msg;
    });


    $scope.cadastrar = function (time)
    {
        $http.post("/Time/Cadastrar", { model: time })
        .success(function (msg) {
            $scope.msg = msg;
        })
        .error(function (msg) {
            $scope.msg = msg;
        });
    }
})