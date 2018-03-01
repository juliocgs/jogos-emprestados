GENERAL.configureDataTable();

$(function () {
    $('#tblGames').DataTable({
        serverSide: true,
        ajax: {
            url: ROOT_URL + 'Game/GetAllGames/'
        },
        columns:
        [
            {
                title: 'Nome',
                data: 'Name',
                width: '50%'
            },
            {
                title: 'Data de Registro',
                data: 'RegistrationDate',
                render: function (data) {
                    return data ? GENERAL.formatDate(data) : '';
                }
            },
            {
                title: 'Preço',
                data: 'Price',
                render: function (data) {
                    return data ? GENERAL.formatMoney(data) : '';
                }
            },
            {
                title: 'Ação',
                data: null,
                orderable: false,
                width: '20%',
                render: function (data, type, row, meta) {
                    var html = '<a href="' + ROOT_URL + 'Game/Edit/' + row.Id + '" class="btn btn-primary btn-xs">Editar</a> ';
                    html += '<a href="' + ROOT_URL + 'Game/Detail/' + row.Id + '" class="btn btn-primary btn-xs">Detalhar</a> ';
                    html += '<a href="' + ROOT_URL + 'Game/Delete/' + row.Id + '" class="btn btn-danger btn-xs">Excluir</a>';

                    return html;
                }
            }
        ]
    });
});