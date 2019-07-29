$(function () {

    $(".table").on("click", ".botao-editar", function () {
        $id = $(this).data("id");
        window.location.replace('/cidade/editar/' + $id)
    });

    function obterTodos() {
        $busca = $("#campo-pesquisa").val();
        $("#lista-cidades").empty();
        $.ajax({
            url: '/cidade/obtertodos',
            method: 'get',
            data: {
                busca: $busca
            },
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    var dado = data[i];

                    var linha = document.createElement("tr");
                    var colunaCodigo = document.createElement("td");
                    colunaCodigo.innerHTML = dado.Id;

                    var colunaNomeEstado = document.createElement("td");
                    colunaNomeEstado.innerHTML = dado.NomeEstado;

                    var colunaNome = document.createElement("td");
                    colunaNome.innerHTML = dado.Nome;

                    var colunaNumeroHabitantes = document.createElement("td");
                    colunaNumeroHabitantes.innerHTML = dado.NumeroHabitantes;

                    var colunaAcao = document.createElement("td");
                    var botaoEditar = document.createElement("button");
                    botaoEditar.classList.add("btn", "btn-primary", "mr-3", "botao-editar");
                    botaoEditar.innerHTML = "Editar";
                    botaoEditar.setAttribute("data-id", dado.Id);

                    var botaoApagar = document.createElement("button");
                    botaoApagar.classList.add("btn", "btn-danger", "botao-apagar");
                    botaoApagar.innerHTML = "Apagar";
                    botaoApagar.setAttribute("data-id", dado.Id);

                    colunaAcao.appendChild(botaoEditar);
                    colunaAcao.appendChild(botaoApagar);

                    linha.appendChild(colunaCodigo);
                    linha.appendChild(colunaNomeEstado);
                    linha.appendChild(colunaNome);
                    linha.appendChild(colunaNumeroHabitantes);
                    linha.appendChild(colunaAcao);
                    document.getElementById("lista-cidades").appendChild(linha);
                }
            }
        })
    }
    window.obterTodos = obterTodos;

    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: '/cidade/apagar/' + $id,
            method: 'get',
            success: function (data) {
                obterTodos();
            },
            error: function (data) {
                console.log('ERRO');
            }
        });
    });

    obterTodos();
});