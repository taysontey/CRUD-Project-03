var myApp = angular.module('myApp', []);

myApp.controller('timeCtrl', function ($scope, $http) {

    $scope.msg = "";
    $scope.times = "";
    $scope.time = "";
    $scope.display = "display:none";

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

    $scope.editar = function (time) {
        $http.post("/Time/Editar", { model: time })
        .success(function (result) {
            $scope.display = "display:block";
            $scope.time = result;
        })
        .error(function (msg) {
            $scope.msg = msg;
        });
    }

    $scope.atualizar = function (time) {
        $http.post("/Time/Edicao", { model: time })
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
    $scope.jogadores = "";

    $http.get("/Jogador/CarregarTimes")
    .success(function (lista) {
        $scope.times = lista;
    })
    .error(function (msg) {
        $scope.msg = msg;
    });

    $http.get("/Jogador/Consultar")
    .success(function (lista) {
        $scope.jogadores = lista;
    })
    .error(function (msg) {
        $scope.msg = msg;
    })

    $scope.cadastrar = function (jogador) {
        $http.post("/Jogador/Cadastrar", { model: jogador })
        .success(function (msg) {
            $scope.msg = msg;
        })
        .error(function (msg) {
            $scope.msg = msg;
        });
    }

    $scope.excluir = function (jogador) {
        $http.post("/Jogador/Excluir", { model: jogador })
        .success(function (msg) {
            $scope.msg = msg;

            window.setTimeout(function () {
                location.reload()
            }, 3000)
        })
        .error(function (msg) {
            $scope.msg = msg;
        })
    }
})