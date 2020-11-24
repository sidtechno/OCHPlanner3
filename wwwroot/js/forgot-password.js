﻿$(document).ready(function () {

    $('#forgot-form').validate({
        rules: {
            'Input.Email': {
                required: true,
                email: true,
            }
        },
        messages: {
            'Input.Email': {
                required: "l'adresse courriel est requise",
                email: "Format de l'adresse courriel est invalide"
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });

    $.urlParam = function (name) {
        return new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    }

    if ($.urlParam('Confirmation')) {
        Swal.fire(
            'Succès!',
            'Le lien à été envoyé, Veuillez vérifier votre boite courriel pour réinitialiser votre mot de passe.',
            'success'
        )
    }
});