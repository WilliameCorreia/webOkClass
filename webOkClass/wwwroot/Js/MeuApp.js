angular.module("MeuApp", []);

angular.module("MeuApp").controller("MeuAppCtrl", function ($scope, $http) {

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

    //$scope.PartialView = function () {
    //    $("#PartialView").load("http://localhost:64944/Home/_PaginaPrincipal");
    //};
         

    CarregarSalas();
});