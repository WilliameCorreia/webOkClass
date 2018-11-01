/// <reference path="../distro/angulajs/angular.js" />

// criação do modulo
var app = angular.module("MeuApp", []);

// criação do controller
app.controller("MeuAppCtrl", function ($scope, $http, $interval) {

    //Carrega a lista e status das salas do banco de dados
    var CarregarSalas = function () {
        $http.get("http://localhost:64944/Home/Dbsalas").then(function (response) {
            $scope.mydata = response.data;
            console.log($scope.mydata);
        });
    };      

    //Envia os status para alterções no banco de dados
    $scope.statusSala = function (status) {
       
        var Obj = $(this.sala).toArray();
        var objSala = Obj[0];

        var id = parseInt(objSala.salaDeAulaId);
        var valor = parseInt(status.selecionado);

        $http({
            method: 'POST',
            url: 'http://localhost:64944/Home/UpdateSala',
            params: { 'id': id, 'valor': valor }
        }).then(function (data, status, headers, config) {
            CarregarSalas();
        });

    };

    //atualização automaticas das informações com o banco de dados 
    $interval(function () {
        CarregarSalas();
    }, 30000);

    // varialvel de inicilização do filtro das salas
    $scope.filtro = "";
    $scope.valor = "1";

    //chamada da função
    CarregarSalas();
});