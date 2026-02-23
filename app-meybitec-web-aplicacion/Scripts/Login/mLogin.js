document.addEventListener("DOMContentLoaded", async function () {

    const form = document.getElementById("formLogin");

    if (!form) {
        console.error("Formulario no encontrado");
        return;
    }

    form.addEventListener("submit", async function (e) {
        console.log("submit OK");
        e.preventDefault();
        let valido = true;

        valido = validarTexto("login__username", "error-login__username", "Ingrese su usuario") && valido;
        valido = validarTexto("login__password", "error-login__password", "Ingrese su contraseña") && valido;

        if (!valido) {
            console.log("Formulario bloqueado por validación");
            return;
        }

        await IngresarMenuprincipal();
    });

    document.querySelectorAll("input, textarea").forEach(e => {
        e.addEventListener("input", validarCampos);
    });
});

async function IngresarMenuprincipal() {
    const form = document.getElementById("formLogin");
    const formData = new FormData(form);

    try {
        const response = await fetch("Login/Login", {
            method: "POST",
            body: formData
        });

        const result = await response.json();
        console.log("Valor data: ", result.data);
        if (result.data.Header?.CodigoRetorno === 0) {
            window.location.href = "/Principal/Index";
        }
        else {
            //Error("Error Login");
            Error(result.Header?.DescRetorno ?? "Error Login");
            LimpiarDatos("formLogin")
        }

    } catch {
        Error("Error en la autenticación de usuario");
        LimpiarDatos("formLogin")
    }
}

function validarTexto(id, errorId, mensaje) {
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

function validarCampos() {
    //const container = this.parentElement;
    //const error = container.querySelector(".error-text");
    console.log("validandoooooooooooo:", this.id);
    const error = document.querySelector(`#error-${this.id}`);

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