async function fetchSeguro(url, options) {
    try {
        const response = await fetch(url, options);

        const result = await response.json();

        //Detectar sesión expirada automaticamente
        if (!result.Ok && result.redirect) {
            window.location.href = result.redirect;
            return null;
        }

        return result;
    }
    catch (error)
    {
        console.error("Error en la petición:", error);
        Error("Ocurrio un error inesperado");
        return null;
    }
}