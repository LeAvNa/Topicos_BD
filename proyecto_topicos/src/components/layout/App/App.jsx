import React from 'react';
import { Outlet } from 'react-router-dom'; // Utiliza Outlet para renderizar los componentes anidados
import Sidebar from '../Sidebar';
import '@mdi/font/css/materialdesignicons.min.css';
import { Col, Row, Container } from 'react-bootstrap';

function App() {
  return (
    <Container fluid>
      <Row style={{ height: '100vh', overflow: 'auto' }}> {/* Cambiado de 'hidden' a 'auto' */}
        <Col
          md={3}
          style={{ padding: 0 }}
        >
          <Sidebar />
        </Col>

        <Col
          md={9}
          style={{
            display: 'flex',
            flexDirection: 'column', // Para asegurarse de que el contenido ocupe el espacio vertical
            justifyContent: 'flex-start', // Cambiado de 'center' para que el contenido no se alinee en el centro
            alignItems: 'stretch', // Asegura que el contenido ocupe todo el ancho
            overflowY: 'auto', // Asegura que el contenido tenga scroll si es necesario
            height: '100vh', // Permite que el scroll funcione en todo el alto
          }}
        >
          <div style={{ width: '100%', padding: '20px' }}>
            <Outlet /> {/* Renderiza los componentes basados en la ruta actual */}
          </div>
        </Col>
      </Row>
    </Container>
  );
}

export default App;