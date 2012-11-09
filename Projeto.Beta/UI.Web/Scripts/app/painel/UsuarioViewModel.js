function UsuarioViewModel() {

    var self = this;
    self.usuarioId = ko.observable('');
    self.nome = ko.observable().extend({ required: { message: "O Nome deve ser preenchido" } });;
    self.login = ko.observable().extend({ required: { message: "O login deve ser preenchido" } });;
    self.senha = ko.observable('');
    self.confirmarSenha = ko.observable('');

    self.informacaoDaTransacao = ko.observable({ mensagens: [] });
    self.listaDeResultados = ko.observableArray();


    self.busca = ko.observable();
    self.filtros = ko.observableArray([{ chave: "NOME", valor: "nome" }, { chave: "LOGIN", valor: "login" }]);
    self.filtroSelecionado = ko.observable();

    self.buscar = function () {
        $.getJSON('/Api/UsuarioApi', { busca: self.busca(), filtro: self.filtroSelecionado() }, function (retorno) {
            self.processaResultadoDaBusca(retorno);
        });
    };

    self.processaResultadoDaBusca = function (resultado) {
        self.limpaMensagensDaTela();
        switch (Object.keys(resultado).length) {
            case 0:
                self.informacaoDaTransacao({ mensagens: ["Não foi encontrado nenhum resultado com esta busca"], alerta: true });
                break;
            case 1:
                self.preencheFormComResultadoDaBusca(resultado[0]);
                self.informacaoDaTransacao({ mensagens: ["Foi encontrado o seguinte registro preenchido abaixo"], alerta: true });
                break;
            default:
                self.informacaoDaTransacao({ mensagens: ["Foram encontrados muitos registros, selecione um para edição"], alerta: true });
                ko.utils.arrayForEach(resultado, function (item) {
                    self.listaDeResultados.push({
                        objeto: item
                    });
                });
                break;
        }
    };

    self.preencheFormComResultadoDaBusca = function (resultado) {
        self.limpaResultadoDaBusca();
        self.usuarioId(resultado.Id);
        self.nome(resultado.Nome);
        self.login(resultado.Login);
    };

    self.limpaResultadoDaBusca = function () {
        self.listaDeResultados([]);
        self.informacaoDaTransacao({ mensagens: [] });
    };

    self.limpaMensagensDaTela = function () {
        self.limpaResultadoDaBusca();

        self.nome('');
        self.login('');
        self.senha('');
        self.confirmarSenha('');
    };

    self.salvar = function () {
        self.limpaResultadoDaBusca();

        if (self.usuarioId() == '') {
            if (self.senha() == '') {
                self.informacaoDaTransacao({ mensagens: ['Preencha o campo senha'], erro: true });
                return;
            }
            if (self.senha() != self.confirmarSenha()) {
                self.informacaoDaTransacao({ mensagens: ['As senhas não conferem'], erro: true });
                return;
            }
        }

        if (vm.isValid()) {
            var usuarioSalvar = {
                Id: self.usuarioId(),
                Nome: self.nome(),
                Login: self.login(),
                Senha: self.senha()
            };

            $.ajax({
                url: '/Api/UsuarioApi',
                type: "POST",
                data: JSON.stringify(usuarioSalvar),
                contentType: 'application/json',
                success: function (retorno) {
                    if (!retorno.TemErro) {
                        self.informacaoDaTransacao({ mensagens: ['Registro Salvo com Sucesso!'], sucesso: true });
                        self.usuarioId(retorno.Retorno.Id);
                    } else {
                        var listaDeErro = [];
                        ko.utils.arrayForEach(retorno.ListaErros, function (mensagem) {
                            listaDeErro.push(mensagem.Valor);
                        });
                        self.informacaoDaTransacao({ mensagens: listaDeErro, erro: true });
                    }
                },
                erro: function (req, status, error) {
                    console.log(req, status, error);
                    self.informacaoDaTransacao({ mensagens: ['Erro desconhecido! consulte o suporte tecnico'], erro: true });
                }
            });

        } else {
            var mensagens = [];
            ko.utils.arrayForEach(vm.errors(), function (mensagem) {
                mensagens.push(mensagem);
            });
            self.informacaoDaTransacao({ mensagens: mensagens, erro: true });
            //vm.errors.showAllMessages(); //mostra erro embaixo dos campos
        }
    };
}

var viewModel = new UsuarioViewModel();
var vm = ko.validatedObservable(viewModel);

$(function () {
    ko.applyBindings(vm);
});