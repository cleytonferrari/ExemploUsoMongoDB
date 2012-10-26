/// <reference path="../Src/knockout.validation.js" />

/************************************************
* This is an example localization page. All of these
* messages are the default messages for ko.validation
* 
* Currently ko.validation only does a single parameter replacement
* on your message (indicated by the {0}).
*
* The parameter that you provide in your validation extender
* is what is passed to your message to do the {0} replacement.
*
* eg: myProperty.extend({ minLength: 5 });
* ... will provide a message of "Please enter at least 5 characters"
* when validated
*
* This message replacement obviously only works with primitives
* such as numbers and strings. We do not stringify complex objects 
* or anything like that currently.
*/

ko.validation.localize({

    required: 'Este campo é obrigatório',
    min: 'Por favor, insira um valor maior ou igual a {0}',
    max: 'Por favor, insira um valor menor ou igual a {0}',
    minLength: 'Por favor, insira ao menos {0} caracteres',
    maxLength: 'Por favor, não insira mais de que {0} caracteres',
    pattern: 'Por favor, verifique este campo',
    step: 'Este valor deve ser multimplo de {0}',
    email: '{0} não é um email válido',
    date: 'Por favor, insira uma data válida',
    dateISO: 'Por favor, insira uma data válida',
    number: 'Por favor, insira um número',
    digit: 'Por favor, insira um digito',
    phoneUS: 'Por favor, insira um número de telefone válido para USA',
    equal: 'Os valores informados devem ser iguais',
    notEqual: 'Por favor, insira outro valor',
    unique: 'Por favor, insira um valor unico para este campo'
});