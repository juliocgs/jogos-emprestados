GENERAL.configureDataTable();

$(function () {
    $('#tblBorrowings').DataTable({
        serverSide: true,
        ajax: {
            url: ROOT_URL + 'Borrowing/GetAllBorrowing/',
            data: function (d) {
                d.id = $('#Id').val()
            }
        },
        columns:
        [
            {
                title: 'Amigo',
                data: 'Friend.Name',
                width: '25%'
            },
            {
                title: 'Jogo',
                data: 'Game.Name',
                width: '25%'
            },
            {
                title: 'Data do empréstimo',
                data: 'BorrowedDate',
                render: function (data) {
                    return GENERAL.formatDate(data);
                }
            },
            {
                title: 'Data de retorno',
                data: 'ReturnDate',
                render: function (data) {
                    return data ? GENERAL.formatDate(data) : '';
                }
            },
            {
                title: 'Ação',
                data: null,
                orderable: false,
                width: '5%',
                render: function (data, type, row, meta) {
                    var html = '<a href="' + ROOT_URL + 'Borrowing/ReturnGame/' + row.Id + '" class="btn btn-primary btn-xs">Devolver</a> ';

                    return row.ReturnDate ? '' : html;
                }
            }
        ]
    });
});