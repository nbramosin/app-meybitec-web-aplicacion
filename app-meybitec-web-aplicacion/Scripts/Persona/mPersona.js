var telefono = document.getElementById("txtTelefono");

soloEnteros(telefono);

document.addEventListener("DOMContentLoaded", async function () {

    const form = document.getElementById("frmMantenimientoPersona");

    if (!form) {
        console.error("Formulario no encontrado");
        return;
    }

    form.addEventListener("submit", async function (e) {
        console.log("submit OK");
        e.preventDefault();
        let valido = true;

        valido = validarTexto("txtNombre", "error-nombre", "Ingrese el nombre") && valido;
        valido = validarTexto("txtApellidoPaterno", "error-apellidoPaterno", "Ingrese el apellido paterno") && valido;
        valido = validarTexto("txtApellidoMaterno", "error-apellidoMaterno", "Ingrese el apellido materno") && valido;
        valido = validarTexto("txtTelefono", "error-telefono", "Ingrese un telefono") && valido;
        valido = validarSelect("cboTipoUsuario", "error-tipoUsuario", "Seleccione un tipo de usuario") && valido;
        valido = validarTexto("txtUsername", "error-userName", "Ingrese un nombre de usuario") && valido;
        valido = validarTexto("txtPassword", "error-password", "Ingrese una contraseña segura") && valido;
        valido = validarGenero() && valido;

        if (!valido)
        {
            console.log("Formulario bloqueado por validación");
            return;
        }

        const confirmado = await Confirmacion(
            "¿Desea guardar la persona?",
            "Confirmación"
        );

        if (!confirmado)
            return;

        await guardarDatosPersonaAJAX();
    });
});

document.querySelectorAll("input, textarea").forEach(e => {
    e.addEventListener("input", validarCampos);
});

document.querySelectorAll("select.form-select").forEach(e => {
    e.addEventListener("change", validarCampos)
});

document.querySelectorAll('input[name="genero"]').forEach(radio => {
    radio.addEventListener("change", () => {
        document.getElementById("error-genero").textContent = "";
    });
});

async function guardarDatosPersonaAJAX()
{
    const form = document.getElementById("frmMantenimientoPersona");
    const formData = new FormData(form);

    var result = await fetchSeguro("/vista/guardarPersona", {
        method: "POST",
        body: formData
    });

    if (!result) return;

    //Error
    if (!result.Ok) {
        Error(result.message ?? "No se pudo guardar");
        return;
    }

    //Correcto
    if (result.data.Header && result.data.Header.CodigoRetorno === 0) {
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: result.data.Header.DescRetorno,
            showConfirmButton: false,
            timer: 1500
        })
        LimpiarDatos("frmMantenimientoPersona")
    }
    else {
        Error(result.data.Header.DescRetorno);
        LimpiarDatos("frmMantenimientoPersona")
        seccionFiltros.classList.remove("d-none");
    }

    //try
    //{
    //    const response = await fetch("/vista/guardarPersona", {
    //        method: "POST",
    //        body: formData
    //    });

    //    const result = await response.json();
    //    console.log("Valor data: ", result.data);
    //    if (result.data.Header && result.data.Header.CodigoRetorno === 0) {
    //        Swal.fire({
    //            position: 'top-end',
    //            icon: 'success',
    //            title: result.data.Header.DescRetorno,
    //            showConfirmButton: false,
    //            timer: 1500
    //        })
    //        LimpiarDatos("frmMantenimientoPersona")
    //    }
    //    else {
    //        Error(result.data.Header.DescRetorno);
    //        LimpiarDatos("frmMantenimientoPersona")
    //        seccionFiltros.classList.remove("d-none");
    //    }
    //}
    //catch
    //{
    //    Error("Error al guardar la persona");
    //    LimpiarDatos("frmMantenimientoPersona")
    //}
}

function validarCampos() {
    const container = this.parentElement;
    //const error = this.closest(".row")?.querySelector(".error-text");
    const error = container.querySelector(".error-text");

    if (!error) return;

    let esValido = true;

    if (this.tagName === "SELECT") {
        esValido = this.value !== "-1"
    }
    else {
        esValido = this.value.trim() !== "";
    }

    if (!esValido) {
        error.textContent = "Este campo es obligatorio";
        this.classList.add("is-invalid");
        this.classList.remove("is-valid");
    } else {
        error.textContent = "";
        this.classList.remove("is-invalid");
        this.classList.add("is-valid");
    }
}

function validarTexto(id, errorId, mensaje) {
    console.log("Ingreso función validarTexto");
    const input = document.getElementById(id);
    const error = document.getElementById(errorId);

    if (!input.value.trim()) {
        input.classList.add("is-invalid");
        input.classList.remove("is-valid");
        error.innerText = mensaje;
        return false;
    }

    input.classList.remove("is-invalid");
    input.classList.add("is-valid");
    error.innerText = "";
    return true;
}

function validarSelect(id, errorId, mensaje) {
    const select = document.getElementById(id);
    const error = document.getElementById(errorId);

    if (select.value == "-1") {
        select.classList.add("is-invalid");
        error.innerText = mensaje;
        return false;
    }

    select.classList.remove("is-invalid");
    select.classList.add("is-valid");
    error.innerText = "";
    return true;
}

function validarNumero(id, errorId, mensaje) {
    const input = document.getElementById(id);
    const error = document.getElementById(errorId);

    if (!input.value || isNaN(input.value) || Number(input.value) <= 0) {
        error.innerText = mensaje;
        input.classList.add("is-invalid");
        return false;
    }

    input.classList.remove("is-invalid");
    input.classList.add("is-valid");
    error.innerText = "";
    return true;
}

function soloEnteros(input) {
    if (!input) return;
    input.addEventListener("input", () => {
        input.value = input.value.replace(/\D/g, "");
    });
}

function validarGenero() {
    const generoSeleccionado = document.querySelector('input[name="genero"]:checked');
    const error = document.getElementById("error-genero");

    if (!generoSeleccionado) {
        error.textContent = "Seleccione un género";
        return false;
    }

    error.textContent = "";
    return true;
}