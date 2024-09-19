import { Form, Button, Col, Row, Container } from 'react-bootstrap';
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useFormik } from 'formik';
import Swal from 'sweetalert2';
import * as Yup from 'yup';

// Importa las acciones relacionadas con cliente y sucursal
import { obtenerCliente, editarCliente } from '../../../../../redux/actions/actionClienteB';
import { listarSucursal } from '../../../../../redux/actions/actionSucursalB';
import InputField from '../../../../common/root/componentes/Input';

const ModificarCliente = ({ onCancel, idCliente }) => {
    const dispatch = useDispatch();
    const [cliente, setCliente] = useState(null);
    const { sucursales } = useSelector(state => state.listarSucursal); // Lista de sucursales

    useEffect(() => {
        if (idCliente) {
            dispatch(obtenerCliente(idCliente))
                .then((response) => {
                    const data = response.payload.response;
                    setCliente(data);
                    formik.setValues({
                        id_cliente: data.id_cliente || '',
                        nom_p: data.nom_p || '',
                        ap_p: data.ap_p || '',
                        ap_m: data.ap_m || '',
                        calle: data.calle || '',
                        num: data.num || '',
                        col: data.col || '',
                        ciudad: data.ciudad || '',
                        estado: data.estado || '',
                        pais: data.pais || '',
                        cp: data.cp || '',
                        correo: data.correo || '',
                        telefono: data.telefono || '',
                        rfc: data.rfc || '',
                        fecha_reg: data.fecha_reg ? data.fecha_reg.split('T')[0] : '',
                        id_sucursal: data.id_sucursal || ''
                    });
                });
        }

        dispatch(listarSucursal()); // Carga las sucursales disponibles
    }, [dispatch, idCliente]);

    const formik = useFormik({
        initialValues: {
            id_cliente: '',
            nom_p: '',
            ap_p: '',
            ap_m: '',
            calle: '',
            num: '',
            col: '',
            ciudad: '',
            estado: '',
            pais: '',
            cp: '',
            correo: '',
            telefono: '',
            rfc: '',
            fecha_reg: '',
            id_sucursal: ''
        },
        validationSchema: Yup.object({
            nom_p: Yup.string().max(30, 'Máximo 30 caracteres').required('Es requerido'),
            ap_p: Yup.string().max(30, 'Máximo 30 caracteres').required('Es requerido'),
            ap_m: Yup.string().max(30, 'Máximo 30 caracteres').required('Es requerido'),
            calle: Yup.string().max(50, 'Máximo 50 caracteres').required('Es requerido'),
            num: Yup.number().required('Es requerido').positive('Debe ser un número positivo'),
            col: Yup.string().max(50, 'Máximo 50 caracteres').required('Es requerido'),
            ciudad: Yup.string().max(30, 'Máximo 30 caracteres').required('Es requerido'),
            estado: Yup.string().max(30, 'Máximo 30 caracteres').required('Es requerido'),
            pais: Yup.string().max(30, 'Máximo 30 caracteres').required('Es requerido'),
            cp: Yup.number().required('Es requerido').positive('Debe ser un número positivo'),
            correo: Yup.string().email('Email inválido').max(50, 'Máximo 50 caracteres').required('Es requerido'),
            telefono: Yup.string().length(10, 'Debe tener 10 dígitos').required('Es requerido'),
            rfc: Yup.string().length(13, 'Debe tener 13 caracteres').required('Es requerido'),
            fecha_reg: Yup.date().required('Es requerido'),
            id_sucursal: Yup.number().required('Es requerido')
        }),
        onSubmit: (values) => {
            dispatch(editarCliente(values))
                .then((response) => {
                    if (!response.error) {
                        Swal.fire({
                            title: "Actualización Correcta",
                            text: "El cliente se actualizó correctamente",
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
        <Container className="d-flex justify-content-center">
            <Row>
                <h2>Editar Cliente</h2>
                <Form onSubmit={formik.handleSubmit}>
                    <Col md={12}>
                        <InputField
                            controlId="nom_p"
                            label="Nombre:"
                            type="text"
                            name="nom_p"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="ap_p"
                            label="Apellido Paterno:"
                            type="text"
                            name="ap_p"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="ap_m"
                            label="Apellido Materno:"
                            type="text"
                            name="ap_m"
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
                            type="number"
                            name="num"
                            formik={formik}
                        />
                    </Col>

                    <Col md={12}>
                        <InputField
                            controlId="col"
                            label="Colonia:"
                            type="text"
                            name="col"
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
                            type="number"
                            name="cp"
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
                            controlId="fecha_reg"
                            label="Fecha de Registro:"
                            type="date"
                            name="fecha_reg"
                            formik={formik}
                        />
                    </Col>

                    {/* Campo para seleccionar la sucursal */}
                    <Col md={12}>
                        <Form.Group controlId="id_sucursal">
                            <Form.Label>Sucursal:</Form.Label>
                            <Form.Control
                                as="select"
                                name="id_sucursal"
                                value={formik.values.id_sucursal}
                                onChange={formik.handleChange}
                            >
                                <option value="">Selecciona una sucursal</option>
                                {sucursales.map((sucursal) => (
                                    <option key={sucursal.id} value={sucursal.id}>
                                        {sucursal.raz_soc}
                                    </option>
                                ))}
                            </Form.Control>
                            {formik.errors.id_sucursal && formik.touched.id_sucursal ? (
                                <div className="text-danger">{formik.errors.id_sucursal}</div>
                            ) : null}
                        </Form.Group>
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

export default ModificarCliente;
