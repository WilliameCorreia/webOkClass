angular.module("MeuApp", []);

angular.module("MeuApp").controller("MeuAppCtrl", function ($scope, $http) {

    
    $http.get("JsonResult").then(function (response) {
        debugger;
        var mydata = response.data;
        
        console.log(mydata);
    })

    var nome = "williame";

    console.log(nome);
});