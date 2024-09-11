import { Form, Button, Col, Row, Container } from 'react-bootstrap';
import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { useFormik } from 'formik';
import Swal from 'sweetalert2';
import * as Yup from 'yup';

// Importa las acciones relacionadas con sucursal
import { obtenerSucursal, editarSucursal } from '../../../../redux/actions/actionSucursal';
import InputField from '../../../common/root/componentes/Input';

const ModificarSucursal = ({ onCancel, idSucursal }) => {
    const dispatch = useDispatch();
    const [sucursal, setSucursal] = useState(null);

    useEffect(() => {
        console.log('ID recibida:', idSucursal); // Imprime la ID en consola
        if (idSucursal) {
            dispatch(obtenerSucursal(idSucursal))
                .then((response) => {
                    console.log('Sucursal obtenida:', response.payload); // Imprime la sucursal obtenida en consola
                    setSucursal(response.payload.response);
                    formik.setValues({
                        idSucursal: response.payload.response.idSucursal || '',
                        razSoc: response.payload.response.razSoc || '',
                        calle: response.payload.response.calle || '',
                        num: response.payload.response.num || '',
                        colonia: response.payload.response.col || '',
                        ciudad: response.payload.response.ciudad || '',
                        estado: response.payload.response.estado || '',
                        pais: response.payload.response.pais || '',
                        cp: response.payload.response.cp || '',
                        presup: response.payload.response.presup || '',
                        telefono: response.payload.response.telefonoSuc || '',
                        rfc: response.payload.response.rfc || '',
                        correo: response.payload.response.correo || '',
                        fechaApertura: response.payload.response.fechaAp || ''
                    });
                });
        }
    }, [dispatch, idSucursal]);

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
        presup: '',
        telefono: '',
        rfc: '',
        correo: '',
        fechaApertura: ''
    };

    const formik = useFormik({
        initialValues: initialValues,
        validationSchema: Yup.object({
            razSoc: Yup.string().required('Es requerido'),
            calle: Yup.string().required('Es requerido'),
            num: Yup.string().required('Es requerido'),
            colonia: Yup.string().required('Es requerido'),
            ciudad: Yup.string().required('Es requerido'),
            estado: Yup.string().required('Es requerido'),
            pais: Yup.string().required('Es requerido'),
            cp: Yup.string().required('Es requerido'),
            presup: Yup.number().required('Es requerido').positive('Debe ser un número positivo'),
            telefono: Yup.string().required('Es requerido'),
            rfc: Yup.string().required('Es requerido'),
            correo: Yup.string().email('Email inválido').required('Es requerido'),
            fechaApertura: Yup.date().required('Es requerido')
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
                    {/* Campos del formulario */}
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
                            controlId="presup"
                            label="Presupuesto:"
                            type="number"
                            name="presup"
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
