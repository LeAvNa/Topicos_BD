import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const listarProveedor = createAsyncThunk("proveedor/listarProveedor",
    async () => {
        try
        {      
            const resp = await axios.get('');

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);

export const obtenerProveedor = createAsyncThunk("proveedor/obtenerProveedor",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const agregarProveedor = createAsyncThunk("proveedor/agregarProveedor",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const eliminarProveedor = createAsyncThunk("proveedor/eliminarProveedor",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.delete('/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const editarProveedor = createAsyncThunk("proveedor/editarProveedor",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.put(``, data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);
