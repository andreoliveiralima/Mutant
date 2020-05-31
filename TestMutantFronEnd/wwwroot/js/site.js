// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function Aguarde() {
    swal({
        title: 'Aguarde...',
        type: 'info',
        background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
        allowOutsideClick: false,
        onOpen: () => {
            swal.showLoading()
        },
        onClose: () => {
        }
    }).then((result) => {
    })
}

function FimAguarde() {
    swal({
        type: 'success',
        title: 'Dados Carregados',
        background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
        showConfirmButton: false,
        timer: 1000
    })
}