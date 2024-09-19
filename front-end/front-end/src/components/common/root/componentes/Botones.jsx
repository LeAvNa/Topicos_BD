import { Button } from "@progress/kendo-react-buttons";
import React from "react";

import { style } from '../../../../constants/Constantes.js';

const BotonNuevo = ({ accion }) => {
    return (
        <Button 
            onClick={() => accion()} 
            variant="success btn-sm" 
            style={style.Nuevo}>
            <span className='mdi mdi-plus'></span> Agregar
        </Button>
    )
};

const BotonEditar = ({ accion }) => {
    return (
        <Button 
            onClick={() => accion()} 
            variant="warning btn-sm" 
            style={style.Modificar}>
            <span className='mdi mdi-file-document-edit'></span> 
        </Button>
    )
};

const BotonEliminar = ({ accion }) => {
    return (
        <Button
            onClick={() => accion()}
            variant="danger btn-sm"
            style={style.Eliminar}
            title={'Eliminar'}
        >
            <i className="mdi mdi-delete"></i>
        </Button>
    )
};

export { BotonNuevo, BotonEditar, BotonEliminar };