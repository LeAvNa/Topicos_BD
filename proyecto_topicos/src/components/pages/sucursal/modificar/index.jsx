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
        idSucursal: '',
        razSoc: '',
        calle: '',
        num: '',
        colonia: '',
        ciudad: '',
        estado: '',
        pais: '',
        cp: '',
        presupuesto: '',
        telefono: '',
        rfc: '',
        correo: '',
        fechaApertura: ''
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
                            controlId="razSoc"
                            label="Razón Social:"
                            type="text"
                            name="razSoc"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="calle"
                            label="Calle:"
                            type="text"
                            name="calle"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="num"
                            label="Número:"
                            type="text"
                            name="num"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="colonia"
                            label="Colonia:"
                            type="text"
                            name="colonia"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="ciudad"
                            label="Ciudad:"
                            type="text"
                            name="ciudad"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="estado"
                            label="Estado:"
                            type="text"
                            name="estado"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="pais"
                            label="País:"
                            type="text"
                            name="pais"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="cp"
                            label="Código Postal:"
                            type="text"
                            name="cp"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="presupuesto"
                            label="Presupuesto:"
                            type="number"
                            name="presupuesto"
                            formik={formik}
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
                            controlId="rfc"
                            label="RFC:"
                            type="text"
                            name="rfc"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="correo"
                            label="Correo:"
                            type="email"
                            name="correo"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="fechaApertura"
                            label="Fecha de Apertura:"
                            type="date"
                            name="fechaApertura"
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