import { useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import { Element } from 'react-scroll';

import TablaSucursales from './buscar/index';
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
    navigate('/sucursal');
    setEsEditar(false);
    setMostrarFormulario(false);
  };

  const handleFormulario = (esEditar = false) => {
    setEsEditar(esEditar);
    setMostrarFormulario(true);

    if (esEditar) {
      navigate('/sucursal/modificar');
    } else {
      navigate('/sucursal/guardar');
    }
  };

  return (
    <Element>
      {mostrarFormulario ? 
      (
        esEditar ? 
          <ModificarSucursal onCancel={mostrarTabla} /> 
        : 
          <GuardarSucursal onCancel={mostrarTabla} /> 
      ) : (
        <TablaSucursales mostrarFormulario={() => handleFormulario()} />
      )}
    </Element> 
  );
};

export default Sucursales;