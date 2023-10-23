var ClickAutomovil = false;
var ClickMoto = false;
function mostrarFormularioDesperfectos() {
    var marcaInput = document.getElementById("vehiculo_Marca");
    var modeloInput = document.getElementById("vehiculo_Modelo");
    var patenteInput = document.getElementById("vehiculo_Patente");
    var CilindradaInput = document.getElementById("cilindradamoto");
    if (ClickAutomovil === true) {
        if (marcaInput.checkValidity() && modeloInput.checkValidity() && patenteInput.checkValidity()) {
            document.getElementById("errorMessageAutomovil").style.display = "none";
        } else {
            document.getElementById("errorMessageAutomovil").style.display = "block";
            return;
        }
    }
    if (ClickMoto === true) {
        if (document.getElementById("marcamoto").checkValidity() && document.getElementById("modelomoto").checkValidity()
            && document.getElementById("patentemoto").checkValidity() && CilindradaInput.checkValidity()) {
            document.getElementById("errorMessageMotocicleta").style.display = "none";
        } else {
            document.getElementById("errorMessageMotocicleta").style.display = "block";
            return;
        }
    }  
    document.getElementById("formularioAutomovil").style.display = "none";
    document.getElementById("formularioMotocicleta").style.display = "none";
    document.getElementById("botonAutomovil").style.display = "none";
    document.getElementById("botonMoto").style.display = "none";
    document.getElementById("formularioDesperfectos").style.display = "block";
    document.getElementById("formularioRepuesto").style.display = "none";
}

function mostrarFormularioCliente() {
    document.getElementById("botonAutomovil").style.display = "none";
    document.getElementById("botonMoto").style.display = "none";
    document.getElementById("pregunta").style.display = "none";
    document.getElementById("formularioCliente").style.display = "block";
    document.getElementById("formularioAutomovil").style.display = "none";
    document.getElementById("formularioDesperfectos").style.display = "none";
    document.getElementById("formularioRepuesto").style.display = "none";
}
function mostrarFormularioAutomovilOMoto() {
    var nombre = document.getElementById("presupuesto_Nombre");
    var apellido = document.getElementById("presupuesto_Apellido");
    var email = document.getElementById("presupuesto_Email");
    var errorMessage = document.getElementById("errorMessageCliente");
    if (nombre.checkValidity() && apellido.checkValidity() && email.checkValidity()) {
        errorMessage.style.display = "none";
    } else {
        errorMessage.style.display = "block";
        return;
    }
    
    document.getElementById("botonAutomovil").style.display = "none";
    document.getElementById("botonMoto").style.display = "none";
    document.getElementById("formularioCliente").style.display = "none";

    if (ClickAutomovil === true) {
        document.getElementById("formularioAutomovil").style.display = "block";
        return;
    }
    if (ClickMoto === true) {
        document.getElementById("formularioMotocicleta").style.display = "block";
        return;
    }
    //document.getElementById("formularioDesperfectos").style.display = "none";
    //document.getElementById("formularioRepuesto").style.display = "none";
}

function ingresarCampoRepuesto() {
    document.getElementById("formularioAutomovil").style.display = "none";
    document.getElementById("botonAutomovil").style.display = "none";
    document.getElementById("botonMoto").style.display = "none";
    document.getElementById("formularioDesperfectos").style.display = "none";
    document.getElementById("formularioRepuesto").style.display = "block";
}
document.getElementById("botonAutomovil").addEventListener("click", function () {
    ClickAutomovil = true;
    ClickMoto = false;
    mostrarFormularioCliente();
});
document.getElementById("botonMoto").addEventListener("click", function () {
    ClickMoto = true;
    ClickAutomovil = false;
    mostrarFormularioCliente();
});

function cambiarTextoBoton() {
    var boton = document.getElementById("botonAgregarRepuesto");
    if (boton.textContent === "Ingresar Repuesto") {
        boton.textContent = "Agregar Repuesto";
    } else if (boton.textContent === "Agregar Repuesto") {
        document.getElementById("formularioRepuesto").style.display = "block";
    }
}
document.getElementById("botonAutomovil").addEventListener("click", mostrarFormularioCliente);
document.getElementById("botonAgregarRepuesto").addEventListener("click", cambiarTextoBoton);

var repuestos = [];

function agregarRepuesto() {
    var descripcionInput = document.getElementById("repuestos_0__Nombre");
    var precioInput = document.getElementById("repuestos_0__Precio");

    var descripcion = descripcionInput.value;
    var precio = parseFloat(precioInput.value);

    if (descripcion && !isNaN(precio)) {
        repuestos.push({ nombre: descripcion, precio: precio });
        mostrarTablaRepuestos();

        descripcionInput.value = "";
        precioInput.value = "";
    }
}

function mostrarTablaRepuestos() {
    var tablaRepuestos = document.querySelector("#tablaRepuestos tbody");
    tablaRepuestos.innerHTML = ""; 

    repuestos.forEach(function (repuesto, index) {
        var row = tablaRepuestos.insertRow();
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);

        var descripcionInput = document.createElement("input");
        descripcionInput.type = "text";
        descripcionInput.name = "repuestos[" + index + "].Nombre";
        descripcionInput.className = "form-control";
        descripcionInput.value = repuesto.nombre;

        var precioInput = document.createElement("input");
        precioInput.type = "number";
        precioInput.name = "repuestos[" + index + "].Precio";
        precioInput.className = "form-control";
        precioInput.value = repuesto.precio;

        cell1.appendChild(descripcionInput);
        cell2.appendChild(precioInput);

        cell3.innerHTML = `<button type="button" onclick="eliminarRepuesto(${index})" class="btn btn-danger btn-sm">Eliminar</button>`;
    });
}

function eliminarRepuesto(index) {
    repuestos.splice(index, 1);
    mostrarTablaRepuestos();
}

function enviarFormulario(e) {
    e.preventDefault();
    Swal.fire({
        title: 'Confirmas los datos incluidos?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Si'
    }).then((resultado) => {
        if (resultado.isConfirmed) {
            document.getElementById('miFormulario').submit();
        }
    });
}

document.getElementById("botonAgregarRepuesto").addEventListener("click", cambiarTextoBoton);
