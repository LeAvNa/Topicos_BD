import { useDispatch, useSelector } from 'react-redux';
import React, { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';
import { EstructuraProveedores } from "../../../../../constants/EstructuraTabla";
import TablaKendo from "../../../../common/root/componentes/TablaKendo";
import { listarProveedor, eliminarProveedor } from '../../../../../redux/actions/actionProveedorB';
import Swal from 'sweetalert2';

const ordenamientoInicial = [
  {
    field: "nombre",
    dir: "asc",
  }
];

const TablaProveedor = ({ mostrarFormulario }) => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const proveedores = useSelector((state) => state.getProveedor.proveedores?.response || []);
  const [dataState, setDataState] = useState([]);

  useEffect(() => {
    dispatch(listarProveedor());
  }, [dispatch]);

  useEffect(() => {
    setDataState(proveedores);
  }, [proveedores]);

  // Función para eliminar la sucursal seleccionada
  const handleEliminar = (idProveedor) => {
    Swal.fire({
      title: "¿Estás seguro?",
      text: "¡No podrás revertir esto!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Sí, eliminar",
      cancelButtonText: "Cancelar"
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch(eliminarSucursal(idProveedor)).then((response) => {
          if (!response.error) {
            Swal.fire({
              title: "Eliminado",
              text: "El proveedor ha sido eliminado.",
              icon: "success"
            });
            dispatch(listarProveedor()); // Recargar las sucursales después de eliminar
          } else {
            Swal.fire({
              title: "Error",
              text: "No se pudo eliminar el proveedor.",
              icon: "error"
            });
          }
        });
      }
    });
  };

  const handleEditar = (idProveedor) => {
    mostrarFormulario(true, idProveedor);
  };

  const handleNuevo = () => {
    mostrarFormulario(false);
  };

  return (
    dataState && (
      <TablaKendo
        estructuraTabla={EstructuraProveedores}
        funcionEditar={handleEditar}
        funcionNuevo={handleNuevo}
        funcionEliminar={handleEliminar}
        data={dataState}
        ordenamientoInicial={ordenamientoInicial}
      />
    )
  );
};

export default TablaProveedor;