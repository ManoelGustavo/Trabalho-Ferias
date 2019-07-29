$(function () {
    $('#campo-pesquisa').on('keyup', function (e) {
        if (e.keyCode == 13) {
            window.obterTodos();
        }
    });
});