
$(document).ready(function () {

    document.getElementById("rdsi").checked = true;
    $("#divvendeimpuestos").show();

})


/*visualizar imagen*/
$("#imagen").change(function () {

    let imagen = this.files[0];

    if (imagen["type"] != "image/jpeg" && imagen["type"] != "image/png") {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("Debe subir una imagen en formato jpeg o png");

    } else if (imagen["size"] > 2000000) {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("La imagen debe tener como maximo 2MB");
    } else {
        var datosImagen = new FileReader;
        datosImagen.readAsDataURL(imagen);

        $(datosImagen).on("load", function (event) {
            var rutaImagen = event.target.result;
            $(".previsualizar").attr("src", rutaImagen);
        })
     
    }

}) 

/***************************************************/

$("#rdsi").on("click", function () {
    document.getElementById("rdno").checked = false;
    document.getElementById("rdsi").checked = true;
    $("#divvendeimpuestos").show();
})

$("#rdno").on("click", function () {
    document.getElementById("rdno").checked = true;
    document.getElementById("rdsi").checked = false;
    $("#divvendeimpuestos").hide();
})

/**************************************************/

$("#btnsiguiente").on("click", function () {

    let nombreempresa = $("#txtnombreempresa").val();

    let rtu = $("#txtrtu").val();

    let email = $("#txtemail").val();

    if (nombreempresa == "") {
        $("#msjnombreempresa").html("* El campo nombre de empresa no debe estar vacío").css("color", "red");
        $("#txtnombreempresa").css("border-color", "red");
        $("#txtnombreempresa").focus();
    }
    else if (rtu == "") {
        $("#msjrtu").html("* El campo RTU no debe estar vacío").css("color", "red");
        $("#txtrtu").css("border-color", "red");
        $("#txtrtu").focus();
    }
    else if (email == "") {
        $("#msjemail").html("* El campo email no debe estar vacío").css("color", "red");
        $("#txtemail").css("border-color", "red");
        $("#txtemail").focus();
    }
    else if (!validaEmail(email)) {
        $("#msjemail").html("* Debe ingresar un email valido").css("color", "red");
        $("#txtemail").css("border-color", "red");
        return false;

    }

    else {

            var paramss = new Object();
            paramss.nombreempresa = nombreempresa;
            paramss.rtu = rtu;
            paramss.email = email;
        

            Post("RegistroEmpresa/validarRegistro", paramss).done(function (datos){
                if (datos.dt.response == "ok") {
                    $(".divregistroempresa").hide();
                    $(".divregistrousersuperadmin").show();

                } else {
                    swal({
                        position: "top-end",
                        type: "error",
                        title: datos.dt.response,
                        text: 'Por favor valide el campo solicitado',
                        showConfirmButton: true,
                        timer: 60000,
                        confirmButtonText: 'Cerrar'
                    })
                }
            })
         }


 })



/**************************************************/
$("#txtnombreempresa").keyup(function () {
    let nombreempresa = $("#txtnombreempresa").val();
    if (nombreempresa == "") {
        $("#msjnombreempresa").html("* El campo nombre de empresa no debe estar vacio").css("color", "red");
        $("#txtnombreempresa").css("border-color", "red");
    } else {
        $("#msjnombreempresa").html("").css("color", "red");
        $("#txtnombreempresa").css("border-color", "");
    }
})

$("#txtrtu").keyup(function () {
    let rtu = $("#txtrtu").val();
    if (rtu == "") {
        $("#msjrtu").html("* El campo RTU no debe estar vacio").css("color", "red");
        $("#txtrtu").css("border-color", "red");
    } else {
        $("#msjrtu").html("").css("color", "red");
        $("#txtrtu").css("border-color", "");
    }
})


$("#txtemail").keyup(function () {
    let email = $("#txtemail").val();
    if (email == "") {
        $("#msjemail").html("* El campo email no debe estar vacio").css("color", "red");
        $("#txtemail").css("border-color", "red");

    } else {
        if (!validaEmail(email)) {
            $("#msjemail").html("* Debe ingresar un email valido").css("color", "red");
            $("#txtemail").css("border-color", "red");
        } else {
            $("#msjemail").html("").css("color", "red");
            $("#txtemail").css("border-color", "");
        }

    }
})
