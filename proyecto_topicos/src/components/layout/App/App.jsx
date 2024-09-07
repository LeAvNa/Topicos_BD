import React from 'react';
import Routes from '../../../route/index';
import Sidebar from '../Sidebar';
import { Col, Row, Container } from 'react-bootstrap';

function App(props) {
  const route = Routes.find((route) => route.path === props.path);
  const ComponentToRender = route.component;

  return (
    <Container fluid>
      <Row style={{ height: '100vh', overflow: 'hidden' }}>
        {/* Sidebar ocupa un ancho fijo */}
        <Col
          md={3} // Cambia este valor si deseas un ancho diferente para la sidebar
          style={{ padding: 0 }}
        >
          <Sidebar />
        </Col>

        {/* Contenido principal ocupa el resto del espacio */}
        <Col
          md={9} // Ajusta este valor en conjunto con el de la sidebar para un diseño equilibrado
          style={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            overflowY: 'auto',
          }}
        >
          <div style={{ width: '100%', padding: '20px' }}>
            <ComponentToRender />
          </div>
        </Col>
      </Row>
    </Container>
  );
}

export default App;