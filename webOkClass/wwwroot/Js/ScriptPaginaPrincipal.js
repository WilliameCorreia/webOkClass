$(document).ready(function () {

    //setTimeout(function () {
    //    $.get("PaginaPrincipal", function () {
    //    });
    //}, 5000);
    //função Entrar na sala
    $(".status").click(function () {
        var valor = parseInt($(this).val());
        var id = parseInt($(this).attr("id"))
        if (confirm("Deseja Entrar nessa sala ?")) {
            $.post("UpdateSala/Salas", { valor: valor, id: id }, function (data) {
                console.log(data);
                window.location.reload();
            }).done(function () {
                console.log("segundo sucess");
            }).fail(function () {
                console.log("Erro");
            }).always(function () {
                console.log("finished");
            })

            
        } else {

        }
        console.log(valor)
        console.log(id);
    });
});