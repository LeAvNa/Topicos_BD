import { useDispatch, useSelector } from 'react-redux';
import React, { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';
import { EstructuraClientes } from "../../../../../constants/EstructuraTabla";
import TablaKendo from "../../../../common/root/componentes/TablaKendo";
import { listarCliente, eliminarCliente } from '../../../../../redux/actions/actionClienteB';
import Swal from 'sweetalert2';

const ordenamientoInicial = [
  {
    field: "nombre",
    dir: "asc",
  }
];

const TablaClientes = ({ mostrarFormulario }) => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const clientes = useSelector((state) => state.getCliente.clientes?.response || []);
  const [dataState, setDataState] = useState([]);

  useEffect(() => {
    dispatch(listarCliente());
  }, [dispatch]);

  useEffect(() => {
    setDataState(clientes);
  }, [clientes]);

  // Función para eliminar la sucursal seleccionada
  const handleEliminar = (idCliente) => {
    Swal.fire({
      title: "¿Estás seguro?",
      text: "¡No podrás revertir esto!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Sí, eliminar",
      cancelButtonText: "Cancelar"
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch(eliminarCliente(idCliente)).then((response) => {
          if (!response.error) {
            Swal.fire({
              title: "Eliminado",
              text: "El cliente ha sido eliminada.",
              icon: "success"
            });
            dispatch(listarCliente()); // Recargar las sucursales después de eliminar
          } else {
            Swal.fire({
              title: "Error",
              text: "No se pudo eliminar el cliente.",
              icon: "error"
            });
          }
        });
      }
    });
  };

  const handleEditar = (idCliente) => {
    mostrarFormulario(true, idCliente);
  };

  const handleNuevo = () => {
    mostrarFormulario(false);
  };

  return (
    dataState && (
      <TablaKendo
        estructuraTabla={EstructuraClientes}
        funcionEditar={handleEditar}
        funcionNuevo={handleNuevo}
        funcionEliminar={handleEliminar}
        data={dataState}
        ordenamientoInicial={ordenamientoInicial}
      />
    )
  );
};

export default TablaClientes;