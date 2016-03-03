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


    $scope.cadastrar = function (time) {
        $http.post("/Time/Cadastrar", { model: time })
        .success(function (msg) {
            $scope.msg = msg;
        })
        .error(function (msg) {
            $scope.msg = msg;
        });
    }

    $scope.excluir = function (time) {
        $http.post("/Time/Excluir", { model: time })
        .success(function (msg) {
            $scope.msg = msg;

            window.setTimeout(function () {
                location.reload()
            }, 3000)
        })
        .error(function (msg) {
            $scope.msg = msg;
        });
    }
})

myApp.controller('jogadorCtrl', function ($scope, $http) {

    $scope.msg = "";
    $scope.times = "";

    $http.get("/Jogador/CarregarTimes")
    .success(function (lista) {
        debugger;
        $scope.times = lista;
    })
    .error(function (msg) {
        $scope.msg = msg;
    });

    $scope.cadastrar = function (jogador) {
        $http.post("/Time/Cadastrar", { model: jogador })
        .success(function (msg) {
            $scope.msg = msg;
        })
        .error(function (msg) {
            $scope.msg = msg;
        });
    }


})