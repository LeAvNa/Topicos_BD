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
  // const { sucursales } = useSelector((state) => state.listarSucursal);
  const [dataState, setDataState] = useState([]);

  // useEffect(() => {
  //   dispatch(listarSucursal());
  // }, [dispatch]);

  // useEffect(() => {
  //   setDataState(sucursales?.items || []);
  // }, [sucursales]);

  //Prueba
  useEffect(() => {
    // Simular la asignación de datos mientras se obtienen los datos reales
    setDataState([
      {
        "razonSocial": "Sucursal A",
        "calle": "Av. Principal",
        "num": "123",
        "colonia": "Centro",
        "ciudad": "Ciudad A",
        "estado": "Estado A",
        "pais": "País A",
        "cp": "12345",
        "presupuesto": "100000",
        "telefono": "123-456-7890",
        "rfc": "RFC123456789",
        "correo": "contacto@sucursalA.com",
        "fechaApertura": "2023-01-01"
      },
      {
        "razonSocial": "Sucursal B",
        "calle": "Calle Secundaria",
        "num": "456",
        "colonia": "Norte",
        "ciudad": "Ciudad B",
        "estado": "Estado B",
        "pais": "País B",
        "cp": "67890",
        "presupuesto": "200000",
        "telefono": "098-765-4321",
        "rfc": "RFC987654321",
        "correo": "contacto@sucursalB.com",
        "fechaApertura": "2023-06-15"
      },
      {
        "razonSocial": "Sucursal C",
        "calle": "Av. Tercera",
        "num": "789",
        "colonia": "Sur",
        "ciudad": "Ciudad C",
        "estado": "Estado C",
        "pais": "País C",
        "cp": "54321",
        "presupuesto": "150000",
        "telefono": "321-654-9870",
        "rfc": "RFC654321098",
        "correo": "contacto@sucursalC.com",
        "fechaApertura": "2023-03-20"
      }
    ]);
  }, []);

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
        data={dataState}
        ordenamientoInicial={ordenamientoInicial}
      />
    )
  );
};

export default TablaSucursales;