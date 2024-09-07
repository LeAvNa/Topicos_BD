import { useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import { Element } from 'react-scroll';

import TablaSucursal from './buscar/index';
import ModificarSucursal from './modificar';
import GuardarSucursal from './guardar';

const Sucursales = () => {
  const navigate = useNavigate();
  const [mostrarFormulario, setMostrarFormulario] = useState(false);
  const [esEditar, setEsEditar] = useState(false);

  useEffect(() => {
    localStorage.setItem('activeMenu', 'Sucursales');
  }, []);
  
  const mostrarTabla = () => {
    navigate('/sucursales');
    setEsEditar(false);
    setMostrarFormulario(false);
  };

  const handleFormulario = (esEditar = false) => {
    setEsEditar(esEditar);
    setMostrarFormulario(true);

    if (esEditar) {
      navigate('/sucursales/modificar');
    } else {
      navigate('/sucursales/guardar');
    }
  };

  return (
    <h2>prueba</h2>
    // <Element>
    //   {mostrarFormulario ? 
    //   (
    //     esEditar ? 
    //       <ModificarSucursal onCancel={mostrarTabla} /> 
    //     : 
    //       <GuardarSucursal onCancel={mostrarTabla} /> 
    //   ) : (
    //     <TablaSucursal mostrarFormulario={() => handleFormulario()} />
    //   )}
    // </Element> 
  );
};

export default Sucursales;