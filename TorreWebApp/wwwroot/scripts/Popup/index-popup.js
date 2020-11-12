var settingModal = {
    show: true,
    keyboard: false,
    backdrop: 'static'
};


var popupObjectList = [
    { id: '1', nombre: 'TipoSitio', titulo: 'Tipo Sitio', nombreCampoAdicional: 'NoMostrar', formDestino: 'formTipoSitioCreate', inputDestino:'exampleInput1' },
    { id: '2', nombre: 'TipoDocumento', titulo: 'Tipo Documento', nombreCampoAdicional: 'Monto', formDestino: 'formTipoSitioCreate', inputDestino: 'exampleInput1'},
]

var popupFunctions = (function () {

    function setPopupFilter(firstLoad, pageNo) {
        var idPopup = $('#formModelName #idPopup').attr('data-modelname');
        var itemParams = popupObjectList.find(item => item.id === idPopup);
        var serialform = $('#formPopupFilter').serialize();
        var nombreCampoAdicional = itemParams.nombreCampoAdicional;
        var nModel = itemParams.nombre;               
        var formDestino = itemParams.formDestino;     
        var inputDestino = itemParams.inputDestino;   
     
        $.ajax({
            url: '../popup/GetPopupListViewSearchResultListAsync',
            type: 'GET',
            data: serialform + "&pageNo=" + pageNo + "&firstLoad=" + firstLoad + "&modelName=" + nModel +
                "&nombreCampoAdicional=" + nombreCampoAdicional + "&formDestino=" + formDestino
                + "&inputDestino=" + inputDestino,
            success: function (data) {
                if (data.success == "true") {
                    if (firstLoad == false) {
                        $('.field-validation-error').html("");
                        $('#collapseOne').removeClass("in");
                        $('#resultContent').html(data.html);
                      
                    }
                }
                if (data.success == "false") {
                    $('#filterContent').html(data.html);
                }
                if (data.success == "error") {
                    $('#filterContent').html(data.html);
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
        var currentPageNo = $("#currentPageNo").val();
        if (currentPageNo > 0) {
            setFrecuenciaFacturaFilter(false, currentPageNo);
        }
    }

    
    
    function showModalBuscar(modelId) {
        var itemParams = popupObjectList.find(item => item.id === modelId);
        $.ajax({
            url: '../Popup/Index',
            type: 'GET',
            data: { idPopup: modelId, titulo: itemParams.titulo, modelName: itemParams.nombre, nombreCampoAdicional: itemParams.nombreCampoAdicional },
            cache: false,
            success: function (form) {
                $("#general-modal .modal-content").html(form).promise().done(function () {
                    $("#general-modal").modal(settingModal);
                    $('#general-modal').modal('show');
                });
         
            }, error: function () {
             
            }
        });
    }


    return {
        showModalBuscar: showModalBuscar,
        refreshTable: refreshTable,
        setPopupFilter: setPopupFilter
    };
})();





//SI SE MANEJAN SELECT2 EN EL MODAL
//$('#modal-FrecuenciaFactura-create').on('shown.bs.modal', function () {
//    $(".select-custom").select2();
//});