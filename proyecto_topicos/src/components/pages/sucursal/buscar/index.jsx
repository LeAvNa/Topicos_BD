import { useDispatch, useSelector } from 'react-redux';
import React, { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';
import { EstructuraSucursales } from "../../../../constants/EstructuraTabla";
import TablaKendo from "../../../common/root/componentes/TablaKendo";
import { listarSucursal, eliminarSucursal } from '../../../../redux/actions/actionSucursal';
import Swal from 'sweetalert2';

const ordenamientoInicial = [
  {
    field: "nombre",
    dir: "asc",
  }
];

const TablaSucursales = ({ mostrarFormulario }) => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const sucursales = useSelector((state) => state.getSucursal.sucursales?.response || []);
  const [dataState, setDataState] = useState([]);

  useEffect(() => {
    dispatch(listarSucursal());
  }, [dispatch]);

  useEffect(() => {
    setDataState(sucursales);
  }, [sucursales]);

  // Función para eliminar la sucursal seleccionada
  const handleEliminar = (idSucursal) => {
    Swal.fire({
      title: "¿Estás seguro?",
      text: "¡No podrás revertir esto!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Sí, eliminar",
      cancelButtonText: "Cancelar"
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch(eliminarSucursal(idSucursal)).then((response) => {
          if (!response.error) {
            Swal.fire({
              title: "Eliminado",
              text: "La sucursal ha sido eliminada.",
              icon: "success"
            });
            dispatch(listarSucursal()); // Recargar las sucursales después de eliminar
          } else {
            Swal.fire({
              title: "Error",
              text: "No se pudo eliminar la sucursal.",
              icon: "error"
            });
          }
        });
      }
    });
  };

  const handleEditar = (idSucursal) => {
    navigate('/sucursal/' + idSucursal);
    mostrarFormulario(idSucursal);
  };

  const handleNuevo = () => {
    navigate('/sucursal/Guardar');
    mostrarFormulario('');
  };

  return (
    dataState && (
      <TablaKendo
        estructuraTabla={EstructuraSucursales}
        funcionEditar={handleEditar}
        funcionNuevo={handleNuevo}
        funcionEliminar={handleEliminar}  // Pasamos la función eliminar
        data={dataState}
        ordenamientoInicial={ordenamientoInicial}
      />
    )
  );
};

export default TablaSucursales;
