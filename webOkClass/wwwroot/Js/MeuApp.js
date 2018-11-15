/// <reference path="../distro/angulajs/angular.js" />

// criação do modulo
var app = angular.module("MeuApp", []);

// criação do controller
app.controller("MeuAppCtrl", function ($scope, $http, $interval) {

 //Carrega a lista e status das salas do banco de dados
    var CarregarSalas = function () {
        $http.get("/Home/Dbsalas").then(function (response) {
            $scope.mydata = response.data;            
         });
    };      

    //chamada da função
    CarregarSalas();

    
    //carrega o usuario logado e suas reservas
    CarregarUsuario = function () {
        var valor = document.getElementById("teste").innerHTML;
        $http({
            method: 'POST',
            url: '/Home/CarregarUsuario',
            params: { 'email': valor }
        }).then(function (data, status, headers, config) {
            console.log(data.data);
            if (data.data.usuario != undefined) {
                $scope.Usuario = data.data.usuario;
                $scope.SalaReservada = data.data.statusReserva;
                $scope.DbSala = data.data.salaDeAula;
            } else {                
                $scope.Usuario = data.data;
                $scope.DbSala = undefined;
            };

            });
        
    };

    //chamada da função
    CarregarUsuario();

   

    //verifica a sala reservada e quem reservou
    $scope.Reserva = function (statusDaSala, numeroDaSala, DbSalaNumeroDaSala) {
        if (statusDaSala == '3') {
            if (numeroDaSala == DbSalaNumeroDaSala) {
                return false;
            } else {
                return true;
            }                     
        }
        else {
            return false;
        }

    }   

    //verifica o tipo de usuario e define as opçoes disponiveis
    $scope.opcoes1 = function (tipoFuncionario, numeroDaSala) {
        if (tipoFuncionario == 1) {
            if (numeroDaSala == undefined) {
                return true;
            } else {
                return false;
            }      
        } else {
            return false;
        }
        
    }

    //verifica o tipo de usuario e define as opçoes disponiveis
    $scope.opcoes2 = function (tipoFuncionario, numeroDaSala) {
        if (tipoFuncionario == 2) {
            return true;
        } else {
            return false;
        }
        
    }
    
    //Envia os status das salas para alterções no banco de dados
    $scope.statusSala = function (status, usuario, statusReserva) {

        var Obj = $(this.sala).toArray();
        var objSala = Obj[0];

        var id = parseInt(objSala.salaDeAulaId);
        var valor = parseInt(status.selecionado);
        var usuario = parseInt(usuario);

        if (valor == 3) {
            $http({
                method: 'POST',
                url: '/Home/SalaReservar',
                params: { 'id': id, 'valor': valor, 'usuario': usuario }
            }).then(function (data, status, headers, config) {
                CarregarSalas();
               CarregarUsuario();
            });
        } else {
            $http({
                method: 'POST',
                url: '/Home/UpdateSala',
                params: { 'id': id, 'valor': valor, 'statusReserva': statusReserva, 'usuario': usuario }
            }).then(function (data, status, headers, config) {
                CarregarSalas();
                CarregarUsuario();
            });
        }    
    };

    //atualização automaticas das informações com o banco de dados 
    $interval(function () {
        CarregarSalas();
    }, 20000);

    // varialvel de inicilização do filtro das salas
    $scope.filtro = "";
    
});