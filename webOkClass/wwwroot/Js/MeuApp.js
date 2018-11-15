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
    $scope.SalaOcupada = function (statusDaSala, salaOcupada, Usuario) {

        if (statusDaSala == 1) {
            var sala = salaOcupada[0];
            if (salaOcupada.length == 1 && sala.usuario.usuarioId == Usuario.usuarioId) {
                return false;
            }
            else {
                return true;
            }
        } else {
            return false;
        }
        

    }   

    //verifica o tipo de usuario e define as opçoes disponiveis
    $scope.opcoes1 = function (usuario, sala) {
        switch (usuario.tipoFuncionario) {
            case 1: {
                return true;
            }break;
            case 2: {
                return false;
            }break;

        }
        
    }

    //verifica o tipo de usuario e define as opçoes disponiveis
    $scope.opcoes2 = function (usuario, sala) {
        switch (usuario.tipoFuncionario) {
            case 1: {
                return false;
            }
                break;
            case 2: {
                return true;
            }
                break;

        }

    }
    
    //Envia os status das salas para alterções no banco de dados
    $scope.statusSala = function (status, usuario, statusReserva) {

        var Obj = $(this.sala).toArray();
        var objSala = Obj[0];

        var id = parseInt(objSala.salaDeAulaId);
        var valor = parseInt(status.selecionado);
        var usuario = parseInt(usuario);

        if (valor == 1 || valor == 2) {
            $http({
                method: 'POST',
                url: '/Home/OcuparSala',
                params: { 'id': id, 'valor': valor, 'usuario': usuario }
            }).then(function (data, status, headers, config) {
                CarregarSalas();
                CarregarUsuario();
                });   
        };
        
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
        };    
    };

    //atualização automaticas das informações com o banco de dados 
    $interval(function () {
        CarregarSalas();
    }, 20000);

    // varialvel de inicilização do filtro das salas
    $scope.filtro = "";
    
});