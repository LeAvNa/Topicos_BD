import React from 'react';
import { Routes, Route, BrowserRouter } from 'react-router-dom';
import { loadMessages } from '@progress/kendo-react-intl';
import mensajesKendo from '../kendo/es.json';

// Componentes
import App from '../../layout/App/App';
import Inicio from '../../pages/inicio/Inicio';
import Sucursal from '../../pages/sucursal';

const Root = () => {
  loadMessages(mensajesKendo, 'es');

  return (
    <React.StrictMode>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<App />}>
            <Route index element={<Inicio />} />
            <Route path="sucursal" element={<Sucursal />} />
            <Route path="sucursal/guardar" element={<Sucursal />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </React.StrictMode>
  );
}

export default Root;