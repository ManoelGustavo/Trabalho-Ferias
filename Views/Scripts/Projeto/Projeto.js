$(function () {

    $(".table").on("click", ".botao-editar", function () {
        $id = $(this).data("id");
        window.location.replace('/projeto/editar/' + $id)
    });

    function obterTodos() {
        $busca = $("#campo-pesquisa").val();
        $("#lista-projetos").empty();
        $.ajax({
            url: '/projeto/obtertodos',
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

                    var colunaNomeCliente = document.createElement("td");
                    colunaNomeCliente.innerHTML = dado.NomeCliente;

                    var colunaNome = document.createElement("td");
                    colunaNome.innerHTML = dado.Nome;

                    var colunaDataCriacaoProjeto = document.createElement("td");
                    colunaDataCriacaoProjeto.innerHTML = new Date(dado.DataCriacaoProjeto).toLocaleDateString();

                    var colunaDataFinalizacao = document.createElement("td");
                    colunaDataFinalizacao.innerHTML = new Date(dado.DataFinalizacao).toLocaleDateString();

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
                    linha.appendChild(colunaNomeCliente);
                    linha.appendChild(colunaNome);
                    linha.appendChild(colunaDataCriacaoProjeto);
                    linha.appendChild(colunaDataFinalizacao);
                    linha.appendChild(colunaAcao);
                    document.getElementById("lista-projetos").appendChild(linha);
                }
            }
        })
    }
    window.obterTodos = obterTodos;

    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: '/projeto/apagar/' + $id,
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