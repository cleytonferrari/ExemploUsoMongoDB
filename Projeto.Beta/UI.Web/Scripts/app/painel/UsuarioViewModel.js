function UsuarioViewModel() {
    var self = this;
    self.nome = ko.observable('Cleyton Ferrari');
    self.login = ko.observable('cleytonFodao');
}

var viewModel = new UsuarioViewModel();
var vm = ko.validatedObservable(viewModel);

$(function () {
    ko.applyBindings(vm);
});