import { Form, Button, Col, Row, Container } from 'react-bootstrap';
import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { useFormik } from 'formik';
import Swal from 'sweetalert2';
import * as Yup from 'yup';

// Importa las acciones relacionadas con sucursal en lugar de empresa
import { obtenerSucursal, editarSucursal } from '../../../../redux/actions/actionSucursal';
import InputField from '../../../common/root/componentes/Input';

const ModificarSucursal = ({ onCancel, idSucursal }) => {
    const dispatch = useDispatch();
    const [sucursal, setSucursal] = useState(null);

    // Valores iniciales del formulario para la sucursal
    const initialValues = {
        nombre: '',
        direccion: '',
        estado: '',
        municipio: '',
        codigoPostal: '',
        colonia: '',
        telefono: '',
        responsable: '', // Cambiado a responsable de la sucursal
        horario: '',     // Campo de horario de la sucursal
    };

    // Configuración de validación con Yup
    const formik = useFormik({
        initialValues: sucursal != null ? sucursal : initialValues,
        validationSchema: Yup.object({
            nombre: Yup.string()
                .required('Es requerido')
                .max(50, 'Máximo 50 caracteres'),
            direccion: Yup.string()
                .required('Es requerido')
                .max(100, 'Máximo 100 caracteres'),
            // Agregar validaciones adicionales para otros campos según sea necesario
        }),
        onSubmit: (values) => {
            dispatch(editarSucursal(values))
                .then((response) => {
                    if (!response.error) {
                        Swal.fire({
                            title: "Actualización Correcta",
                            text: "La sucursal se actualizó correctamente",
                            icon: "success",
                            showCancelButton: false,
                            confirmButtonText: "Aceptar",
                        });
                        LimpiarCampos();
                    }
                });
        },
        enableReinitialize: true
    });

    useEffect(() => {
        if (idSucursal !== '') {
            dispatch(obtenerSucursal(idSucursal))
                .then((response) => {
                    setSucursal(response.payload);
                });
        }
    }, [dispatch, idSucursal]);

    const LimpiarCampos = () => {
        formik.resetForm();
        onCancel();
    };

    const handleCancel = () => {
        LimpiarCampos();
    }

    return (
        <Container className='d-flex justify-content-center'>
            <Row>
                <h2>Editar Sucursal</h2>
                <Form onSubmit={formik.handleSubmit}>
                    <Col md={12}>
                        <InputField
                            controlId="nombre"
                            label="Nombre:"
                            type="text"
                            name="nombre"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="direccion"
                            label="Dirección:"
                            type="text"
                            name="direccion"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="estado"
                            label="Estado:"
                            type="select"
                            name="estado"
                            formik={formik}
                            options={[]} // Ajusta opciones de estado según tus datos
                            placeholder="Seleccione un estado"
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="municipio"
                            label="Municipio:"
                            type="select"
                            name="municipio"
                            formik={formik}
                            options={[]} // Ajusta opciones de municipio según tus datos
                            placeholder="Seleccione un municipio"
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="codigoPostal"
                            label="Código Postal:"
                            type="text"
                            name="codigoPostal"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="colonia"
                            label="Colonia:"
                            type="select"
                            name="colonia"
                            formik={formik}
                            options={[]} // Ajusta opciones de colonia según tus datos
                            placeholder="Seleccione una colonia"
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="telefono"
                            label="Teléfono:"
                            type="text"
                            name="telefono"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="responsable"
                            label="Responsable:"
                            type="text"
                            name="responsable"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="horario"
                            label="Horario:"
                            type="text"
                            name="horario"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12} style={{ paddingTop: "10px" }}>
                        <div className="mt-3 d-flex justify-content-end">
                            <Button
                                className='mx-3'
                                variant="danger"
                                onClick={handleCancel}>
                                Cancelar
                            </Button>
                            <Button
                                className=''
                                variant="primary"
                                type="submit">
                                Guardar
                            </Button>
                        </div>
                    </Col>
                </Form>
            </Row>
        </Container>
    );
};

export default ModificarSucursal;