$(function () {
    $id = -1;
    $(".table").on("click", ".botao-editar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: '/estado/obterpeloid/' + $id,
            method: 'get',
            success: function (data) {
                $id = data.Id;
                $("#campo-nome").val(data.Nome);
                $("#campo-sigla").val(data.Sigla)
                $("#modalCadastroEstado").modal("show");
            },
        });
    });

    $("#campo-pesquisa").on("keyup", function (e) {
        if (e.keyCode == 13) {
            obterTodos();
        }
    })
    function obterTodos() {
        $busca = $("#campo-pesquisa").val();
        $("#lista-estados").empty();
        $.ajax({
            url: '/estado/obtertodos',
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

                    var colunaNome = document.createElement("td");
                    colunaNome.innerHTML = dado.Nome;

                    var colunaSigla = document.createElement("td");
                    colunaSigla.innerHTML = dado.Sigla;

                    var colunaAcao = document.createElement("td");
                    var botaoEditar = document.createElement("button");
                    botaoEditar.classList.add("btn", "btn-primary", "mr-3", "botao-editar");
                    botaoEditar.innerHTML = "<i class=\"fas fa-pen\"></i> Editar";
                    botaoEditar.setAttribute("data-id", dado.Id);

                    var botaoApagar = document.createElement("button");
                    botaoApagar.innerHTML = "<i class=\"fas fa-trash\"></i> Apagar";
                    botaoApagar.classList.add("btn", "btn-danger", "botao-apagar");
                    botaoApagar.setAttribute("data-id", dado.Id);

                    colunaAcao.appendChild(botaoEditar);
                    colunaAcao.appendChild(botaoApagar);

                    linha.appendChild(colunaCodigo);
                    linha.appendChild(colunaNome);
                    linha.appendChild(colunaSigla);
                    linha.appendChild(colunaAcao);
                    document.getElementById("lista-estados").appendChild(linha);
                }
            }
        })
    }

    $("#estado-botao-salvar").on("click", function () {
        if ($id == -1) {
            inserir();
        } else {
            alterar();
        }
    });

    function alterar() {
        $nome = $("#campo-nome").val();
        $sigla = $("#campo-sigla").val();
        $.ajax({
            method: "post",
            url: "/estado/update",
            data: {
                Nome: $nome,
                Sigla: $sigla,
                Id: $id
            },
            success: function (data) {
                $id = -1;
                $("#modalCadastroEstado").modal("hide");
                obterTodos();
            },
            error: function (data) {
                console.log("ERRO");
            }
        });
    };

    function inserir() {
        $nome = $("#campo-nome").val();
        $sigla = $("#campo-sigla").val();
        $.ajax({
            method: "post",
            url: "/estado/store",
            data: {
                Nome: $nome,
                Sigla: $sigla
            },
            success: function (data) {
                $id = -1;
                $("#modalCadastroEstado").modal("hide");
                obterTodos();
            },
            error: function (data) {
                console.log("ERRO");
            }
        });
    };

    function limparCampos() {
        $("#campo-nome").val("");
        $("#campo-sigla").val("");
    };

    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: '/estado/apagar/' + $id,
            method: 'get',
            success: function (data) {
                obterTodos();
            },
            error: function (data) {
                console.log('Deu ruim filhão');
            }
        });
    });

    obterTodos();
});