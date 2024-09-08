import { Form, Col } from 'react-bootstrap';
import React, { useEffect } from 'react';

const InputField = ({
  controlId,    // Identificador del campo de formulario
  label,        // Etiqueta del campo de formulario
  type,         // Tipo de entrada (por ejemplo, texto o select)
  name,         // Nombre del campo de formulario
  formik,       // Objeto de Formik para la gestión de formularios (opcional)
  options,      // Opciones para campos de tipo 'select' (opcional)
  onChange,     // Función de cambio personalizada (opcional)
  placeholder,  // Marcador de posición para el campo de formulario (opcional)
  valor         // Valor inicial del campo de formulario (opcional)
}) => {
  const handleChange = formik && !onChange ? formik.handleChange : onChange || (() => {});
  const handleBlur = formik ? formik.handleBlur : () => {};
  const value = formik ? formik.values[name] : valor || '';

  useEffect(() => {
    if (!valor && !formik) {
      if (type === 'select') {
        const Input = document.getElementById(controlId);
        Input.selectedIndex = '';
      } else {
        if(formik){
          const Input = document.getElementById(controlId);
          Input.value = formik.values[name];
        }else{
          const Input = document.getElementById(controlId);
          Input.value = '';
        }
      }
    }
  }, [valor, controlId, type, label, formik, name]);

  return (
    // Renderización del componente
    <Col md={12}>
      <Form.Group controlId={controlId}>
        <Form.Label>{label}</Form.Label>
        {type === 'select' ? (
          <Form.Control
            as="select"
            name={name}
            onChange={handleChange}
            onBlur={handleBlur}
            value={value}
          >
            <option value={''}>Seleccione uno...</option>
            {options && options.map((option) => (
              <option key={option.slug} value={option.slug}>
                {option.nombre}
              </option>
            ))}
          </Form.Control>
        ) : (
          <Form.Control
            type={type}
            name={name}
            placeholder={placeholder}
            onChange={handleChange}
            onBlur={handleBlur}
            value={value}
          />
        )}
        {formik && formik.touched[name] && formik.errors[name] ? (
          <div className="validation-message">{formik.errors[name]}</div>
        ) : null}
      </Form.Group>
    </Col>
  );
};

export default InputField;