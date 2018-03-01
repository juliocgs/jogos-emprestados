'use strict';

$(function () {
});

var GENERAL = {
    configureDataTable: function () {
        $.extend($.fn.dataTable.defaults, {
            searching: false,
            lengthChange: false,
            processing: true,
            ordering: false,
            language: {
                decimal: '',
                emptyTable: 'Não há itens na listagem',
                info: 'Mostrando de _START_ até _END_ de _TOTAL_ itens',
                infoEmpty: '',
                infoFiltered: '(filtrado de _MAX_ itens)',
                infoPostFix: '',
                thousands: '.',
                lengthMenu: 'Monstrando _MENU_ itens',
                loadingRecords: 'Carregando...',
                processing: 'Carregando...',
                search: 'Pesquisa:',
                zeroRecords: 'Não há itens na listagem',
                paginate: {
                    first: 'Primeira',
                    last: 'Último',
                    next: 'Próximo',
                    previous: 'Anterior'
                },
                aria: {
                    sortAscending: ': ative para ordenar de forma crescente',
                    sortDescending: ': ative para ordenar de forma decrescente'
                }
            }
        });
    },

    formatMoney: function (n) {
        return 'R$' + n.toFixed(2).replace('.', ',').replace(/(\d)(?=(\d{3})+\,)/g, "$1.");
    },

    formatDate: function (d) {
        var date = new Date(d);

        return ('0' + date.getDate()).slice(-2) + '/' + ('0' + (date.getMonth() + 1)).slice(-2) + '/' + date.getFullYear();
    }
};