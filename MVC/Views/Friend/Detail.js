GENERAL.configureDataTable();

$(function () {
    $('#tblBorrowings').DataTable({
        serverSide: true,
        ajax: {
            url: ROOT_URL + 'Friend/GetAllBorrowing/',
            data: function (d) {
                d.id = $('#Id').val()
            }
        },
        columns:
        [
            {
                title: 'Jogo',
                data: 'Game.Name'
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
            }
        ]
    });
});