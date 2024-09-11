import { useDispatch, useSelector } from 'react-redux';
import React, { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';

import { EstructuraSucursales } from "../../../../constants/EstructuraTabla";
import TablaKendo from "../../../common/root/componentes/TablaKendo";
import { listarSucursal } from '../../../../redux/actions/actionSucursal';

const ordenamientoInicial = [
  {
    field: "nombre",
    dir: "asc",
  }
];

const TablaSucursales = ({ mostrarFormulario }) => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  // Accedemos a "response" dentro del estado de sucursales
  const sucursales = useSelector((state) => state.getSucursal.sucursales?.response || []);
  const [dataState, setDataState] = useState([]);

  useEffect(() => {
    dispatch(listarSucursal());
  }, [dispatch]);

  useEffect(() => {
    setDataState(sucursales); // Aquí ya estamos obteniendo el array directamente
  }, [sucursales]);

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
        data={dataState}  // Pasamos directamente el array de sucursales
        ordenamientoInicial={ordenamientoInicial}
      />
    )
  );
};

export default TablaSucursales;