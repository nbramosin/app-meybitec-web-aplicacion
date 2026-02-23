const stockInput = document.getElementById("txtStock");
const precioBaseInput = document.getElementById("txtPrecioBase");
const precioOfertaInput = document.getElementById("txtPrecioOferta");
const descuentoInput = document.getElementById("txtDescuento");

const cboCategoria = document.getElementById("cboCategoria");
const seccionFiltros = document.getElementById("seccion-filtros");

soloEnteros(stockInput);
soloDecimal(precioBaseInput, 2);
soloDecimal(precioOfertaInput, 2);
soloDecimal(descuentoInput, 2);

document.addEventListener("DOMContentLoaded", async function () {
    console.log("DOM cargado");

    const form = document.getElementById("frmMantenimientoProducto");

    if (!form) {
        console.error("Formulario no encontrado");
        return;
    }

    form.addEventListener("submit", async function (e) {
        //alert("pinchaste en el btón guardar");
        console.log("submit OK");
        e.preventDefault();
        let valido = true;

        //valido = validarTexto("txtSku", "error-sku", "Ingrese el sku") && valido;
        valido = validarTexto("txtNombreProd", "error-nombreProd", "Ingrese el nombre del producto") && valido;
        valido = validarTexto("txtDescripcionProd", "error-descripcionProd", "Ingrese la descripción del producto") && valido;
        valido = validarTexto("txtMarcaReferencia", "error-marcaReferencia", "Ingrese la marca de referencia del producto") && valido;
        valido = validarSelect("cboMarca", "error-marca", "Seleccione una marca") && valido;
        valido = validarNumero("txtStock", "error-stock", "Ingrese stock válido") && valido;
        valido = validarSelect("cboCategoria", "error-categoria", "Seleccione una categoria") && valido;
        valido = validarSelect("cboConexiones", "error-conexiones", "Seleccione una conexión") && valido;
        valido = validarSelect("cboTiposCategoria", "error-tiposCategoria", "Seleccione un tipo categoria") && valido;
        valido = validarSelect("cboLongitud", "error-longitud", "Seleccione una longitud") && valido;
        valido = validarTexto("txtPrecioBase", "error-precioBase", "Ingrese precio base") && valido;
        //valido = validarTexto("txtPrecioOferta", "error-precioOferta", "Ingrese precio oferta") && valido;
        //valido = validarTexto("txtDescuento", "error-descuento", "Ingrese descuento") && valido;
        valido = validarTexto("txtFechaInicio", "error-fechaInicio", "Ingrese una fecha inicio") && valido;
        valido = validarTexto("txtFechaFin", "error-fechaFin", "Ingrese una fecha fin") && valido;
        valido = validarTexto("txtImagenes", "error-imagenes", "Agregue uno o mas imagenes") && valido;

        if (!valido) {
            //e.preventDefault();
            console.log("Formulario bloqueado por validación");
            return;
        }

        const confirmado = await Confirmacion(
            "¿Desea guardar el producto?",
            "Confirmación"
        );

        if (!confirmado)
            return;
        //Correcto("Producto guardado correctamente");
        //LimpiarDatos("frmMantenimientoProducto");
        await guardarDatosProductoAJAX();
    });
});

cboCategoria.addEventListener("change", function () {

    const valor = this.value;

    console.log("valor seleccionado categoria: ", valor);

    if (valor == 1 || valor == 2) {
        seccionFiltros.classList.remove("d-none");
    } else {
        seccionFiltros.classList.add("d-none");
    }
})
    

document.querySelectorAll("input, textarea").forEach(e => {
    e.addEventListener("input", validarCampos);
});

document.querySelectorAll("select.form-select").forEach(e => {
    e.addEventListener("change", validarCampos)
});

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

async function guardarDatosProductoAJAX() {
    const form = document.getElementById("frmMantenimientoProducto");
    const formData = new FormData(form);

    const result = await fetchSeguro("/vista/guardarProducto", {
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
    if (result?.data?.Header?.CodigoRetorno === 0) {
        Correcto(result.data.Header.DescRetorno, result);
        LimpiarDatos("frmMantenimientoProducto")
    }
    else {
        Error(result?.data?.Header?.DescRetorno ?? "Error inesperado");
        LimpiarDatos("frmMantenimientoProducto")
        seccionFiltros.classList.remove("d-none");
    }

    //try
    //{
    //    const response = await fetch("/vista/guardarProducto", {
    //        method: "POST",
    //        body: formData
    //    });

    //    const result = await response.json();
    //    console.log("Valor data: ", result.data);
    //    if (!result.Ok && result.redirect) {
    //        window.location.href = result.redirect;
    //        return;
    //    }

    //    if (result?.data?.Header?.CodigoRetorno === 0) {
    //        Correcto(result.data.Header.DescRetorno, result);
    //        LimpiarDatos("frmMantenimientoProducto")
    //    }
    //    else {
    //        Error(result?.data?.Header?.DescRetorno ?? "Error inesperado");
    //        LimpiarDatos("frmMantenimientoProducto")
    //        seccionFiltros.classList.remove("d-none");
    //    }
    //}
    //catch (error)
    //{
    //    //console.error("Error:", error);
    //    Error("Error al guardar el producto");
    //    LimpiarDatos("frmMantenimientoProducto")
    //} 
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
function validarFechas(iniId, finId) {
    const fecIni = new Date(document.getElementById(iniId).value);
    const fecFin = new Date(document.getElementById(finId).value);
    return fecFin >= fecIni;
}

function validarImagenes(inputId) {
    const files = document.getElementById(inputId).files;
    return files.length > 0;
}

function soloEnteros(input) {
    if (!input) return;
    input.addEventListener("input", () => {
        input.value = input.value.replace(/\D/g, "");
    });
}

function soloDecimal(input, maxDecimales) {
    if (!input) return;
    input.addEventListener("input", () => {
        let valor = input.value
            .replace(/[^0-9.]/g, "")
            .replace(/(\..*)\./g, "$1");

        if (valor.includes(".")) {
            const partes = valor.split(".");
            partes[1] = partes[1].slice(0, maxDecimales);
            valor = partes.join(".");
        }

        input.value = valor;
    });
}
function previewImages(input) {
    console.log("valor imput files", input.files)
    const preview = document.getElementById("preview")

    preview.innerHTML = "";

    if (input.files) {
        Array.from(input.files).forEach(file => {
            const reader = new FileReader();

            reader.onload = function (e) {
                const col = document.createElement("div");
                col.className = "col-md-2 mb-2"

                col.innerHTML = `
                        <img src="${e.target.result}"
                             class="img-thumbnail"
                             style="height:120px; object-fit:cover; border: 0px solid">
                    `;

                preview.appendChild(col);
            }
            reader.readAsDataURL(file);
        });
    }
}