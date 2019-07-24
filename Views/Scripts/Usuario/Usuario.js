$(function () {
    $id = -1;
    $(".table").on("click", ".botao-editar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: '/usuario/obterpeloid/' + $id,
            method: 'get',
            success: function (data) {
                $id = data.Id;
                $("#campo-nome").val(data.Nome);
                $("#campo-login").val(data.Login);
                $("#campo-senha").val(data.Senha);
                $("#modalCadastroUsuario").modal("show");
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
        $("#lista-usuarios").empty();
        $.ajax({
            url: '/usuario/obtertodos',
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

                    var colunaLogin = document.createElement("td");
                    colunaLogin.innerHTML = dado.Login;

                    var colunaSenha = document.createElement("td");
                    colunaSenha.innerHTML = dado.Senha;

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
                    linha.appendChild(colunaLogin);
                    linha.appendChild(colunaSenha);
                    linha.appendChild(colunaAcao);
                    document.getElementById("lista-usuarios").appendChild(linha);
                }
            }
        })
    }

    $("#usuario-botao-salvar").on("click", function () {
        if ($id == -1) {
            inserir();
        } else {
            alterar();
        }
    });

    function alterar() {
        $nome = $("#campo-nome").val();
        $login = $("#campo-login").val();
        $senha = $("#campo-senha").val();
        $.ajax({
            method: "post",
            url: "/usuario/update",
            data: {
                Nome: $nome,
                Login: $login,
                Senha: $senha,
                Id: $id
            },
            success: function (data) {
                $id = -1;
                $("#modalCadastroUsuario").modal("hide");
                obterTodos();
            },
            error: function (data) {
                console.log("ERRO");
            }
        });
    };

    function inserir() {
        $nome = $("#campo-nome").val();
        $login = $("#campo-login").val();
        $senha = $("#campo-senha").val();
        $.ajax({
            method: "post",
            url: "/usuario/store",
            data: {
                Nome: $nome,
                Login: $login,
                Senha: $senha
            },
            success: function (data) {
                $id = -1;
                $("#modalCadastroUsuario").modal("hide");
                obterTodos();
            },
            error: function (data) {
                console.log("ERRO");
            }
        });
    };

    function limparCampos() {
        $("#campo-nome").val("");
        $("#campo-login").val("");
        $("#campo-senha").val("");
    };

    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: '/usuario/apagar/' + $id,
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