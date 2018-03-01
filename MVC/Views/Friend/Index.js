GENERAL.configureDataTable();

$(function () {
    $('#tblFriends').DataTable({
        serverSide: true,
        ajax: {
            url: ROOT_URL + 'Friend/GetAllFriends/'
        },
        columns:
        [
            {
                title: 'Nome',
                data: 'Name'
            },
            {
                title: 'Apelido',
                data: 'NickName'
            },
            {
                title: 'E-mail',
                data: 'Email'
            },
            {
                title: 'Telefone',
                data: 'PhoneNumber'
            },
            {
                title: 'Ação',
                data: null,
                orderable: false,
                width: '20%',
                render: function (data, type, row, meta) {
                    var html = '<a href="' + ROOT_URL + 'Friend/Edit/' + row.Id + '" class="btn btn-primary btn-xs">Editar</a> ';
                    html += '<a href="' + ROOT_URL + 'Friend/Detail/' + row.Id + '" class="btn btn-primary btn-xs">Detalhar</a> ';
                    html += '<a href="' + ROOT_URL + 'Friend/Delete/' + row.Id + '" class="btn btn-danger btn-xs">Excluir</a>';

                    return html;
                }
            }
        ]
    });
});