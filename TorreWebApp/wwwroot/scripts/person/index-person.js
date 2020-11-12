var titleList = '<h2>Person <small style="color:gold"><span style="padding-right:5px; padding-left:5px" class="glyphicon glyphicon-th-list"></span>List</small></h2>';
var titleModifiy = '<h2>Person <small style="color:gold"><span style="padding-right:5px; padding-left:5px" class="glyphicon glyphicon-pencil"></span>Details</small></h2>';

var PersonFunctions = (function () {

    function setPersonFilter(firstLoad, pageNo) {
        var serialform = $('#formPersonFilter').serialize();
      
        $.ajax({
            url: '../Person/GetList',
            type: 'GET',
            data: serialform + '&pageNo=' + pageNo + '&firstLoad=' + firstLoad,
            success: function (data) {
                if (data.success == 'true') {
                    if (firstLoad == false) {
                        $('.field-validation-error').html('');
                        $('#collapseOne').removeClass('in');
                        $('#resultContent').html(data.html);
                    }
                }
                if (data.success == 'false') {
                    $('#filterContent').html(data.html);
                }
                if (data.success== 'error') {
                    $('#filterContent').html(data.html);
                    alert(data.message);
                }
                if (data.success == 'error') {
                    $('#filterContent').html(data.html);
                    $('#resultContent').html(data.html);
                    alert(data.message);
                }
            },
            error: function (data) {
                $('#filterContent').html(data.html);
            },
            complete: function (xhr, status) {


            }
        });
    }

    function refreshTable() {
        var currentPageNo = $('#currentPageNo').val();
        if (currentPageNo > 0) {
            setPersonFilter(false, currentPageNo);
        }
    }

    function clearFilter() {
        form = $('#formPersonFilter');
        form.find(':input').not(':button, :submit, :reset, :hidden, :checkbox, :radio').val('');
        form.find(':checkbox, :radio').prop('checked', false);
        $('.field-validation-error').html('');
        
    }

    function saveCancel() {
       
        $('#resultContent').show();
        $('#filterContent').show();
        $('#resultContentCreate').html('');
        $('#resultContentCreate').hide();
        $('#filterContent .select-custom').select2();
        $('#header-descripcion').html(titleList);
    }

    function detailCancel() {

        $('#resultContent').show();
        $('#filterContent').show();
        $('#resultContentDetail').html('');
        $('#resultContentDetail').hide();
        $('#filterContent .select-custom').select2();
        $('#header-descripcion').html(titleList);
    }

 

    function showEdit(id) {
       
        $.ajax({
            url: '../Person/GetPeopleAsync',
            type: 'GET',
            data: { nombreUsuario: id},
            cache: false,
            success: function (form) {
                $('#resultContentDetail').html(form).promise().done(function () {
                    $('#resultContent').hide();
                    $('#filterContent').hide();
                    $('#resultContentDetail').show();
                    $('#header-descripcion').html(titleModifiy);
                });
            }, error: function () {

            }
        });
    }

   

 

   

   

    return {
        setPersonFilter: setPersonFilter,
        clearFilter: clearFilter,
        detailCancel: detailCancel,
        showEdit: showEdit
      
    };
})();

$(document).ready(function () {
    PersonFunctions.setPersonFilter(true, 1);
 
});





