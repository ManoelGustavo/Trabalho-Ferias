$(function () {

    $(".table").on("click", ".botao-editar", function () {
        $id = $(this).data("id");
        window.location.replace('/cliente/editar/' + $id)
    });

    function obterTodos() {
        $busca = $("#campo-pesquisa").val();
        $("#lista-clientes").empty();
        $.ajax({
            url: '/cliente/obtertodos',
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

                    var colunaCpf = document.createElement("td");
                    colunaCpf.innerHTML = dado.Cpf;

                    var colunaDataNascimento = document.createElement("td");
                    colunaDataNascimento.innerHTML = new Date(dado.DataNascimento).toLocaleDateString();

                    var colunaNomeCidade = document.createElement("td");
                    colunaNomeCidade.innerHTML = dado.NomeCidade;

                    var colunaCep = document.createElement("td");
                    colunaCep.innerHTML = dado.Cep;

                    var colunaNumero = document.createElement("td");
                    colunaNumero.innerHTML = dado.Numero;

                    var colunaComplemento = document.createElement("td");
                    colunaComplemento.innerHTML = dado.Complemento;

                    var colunaLogradouro = document.createElement("td");
                    colunaLogradouro.innerHTML = dado.Logradouro;

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
                    linha.appendChild(colunaNome);
                    linha.appendChild(colunaCpf);
                    linha.appendChild(colunaDataNascimento);
                    linha.appendChild(colunaNomeCidade);
                    linha.appendChild(colunaCep);
                    linha.appendChild(colunaNumero);
                    linha.appendChild(colunaComplemento);
                    linha.appendChild(colunaLogradouro);
                    linha.appendChild(colunaAcao);
                    document.getElementById("lista-clientes").appendChild(linha);
                }
            }
        })
    }
    window.obterTodos = obterTodos;

    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: '/cliente/apagar/' + $id,
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