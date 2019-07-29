$(function () {

    $(".table").on("click", ".botao-editar", function () {
        $id = $(this).data("id");
        window.location.replace('/tarefa/editar/' + $id)
    });

    function obterTodos() {
        $busca = $("#campo-pesquisa").val();
        $("#lista-tarefas").empty();
        $.ajax({
            url: '/tarefa/obtertodos',
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

                    var colunaNomeUsuario = document.createElement("td");
                    colunaNomeUsuario.innerHTML = dado.NomeUsuario;

                    var colunaNomeProjeto = document.createElement("td");
                    colunaNomeProjeto.innerHTML = dado.NomeProjeto;

                    var colunaNomeCategoria = document.createElement("td");
                    colunaNomeCategoria.innerHTML = dado.NomeCategoria;

                    var colunaTitulo = document.createElement("td");
                    colunaTitulo.innerHTML = dado.Titulo;

                    var colunaDescricao = document.createElement("td");
                    colunaDescricao.innerHTML = dado.Descricao;

                    var colunaDuracao = document.createElement("td");
                    colunaDuracao.innerHTML = new Date(dado.Duracao).toLocaleTimeString();

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
                    linha.appendChild(colunaNomeUsuario);
                    linha.appendChild(colunaNomeProjeto);
                    linha.appendChild(colunaNomeCategoria);
                    linha.appendChild(colunaTitulo);
                    linha.appendChild(colunaDescricao);
                    linha.appendChild(colunaDuracao);
                    linha.appendChild(colunaAcao);
                    document.getElementById("lista-tarefas").appendChild(linha);
                }
            }
        })
    }
    window.obterTodos = obterTodos;

    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: '/tarefa/apagar/' + $id,
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