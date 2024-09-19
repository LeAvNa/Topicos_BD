import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const listarInventario = createAsyncThunk("inventario/listarInventario",
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

export const obtenerInventario = createAsyncThunk("inventario/obtenerInventario",
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

export const agregarInventario = createAsyncThunk("inventario/agregarInventario",
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

export const eliminarInventario = createAsyncThunk("inventario/eliminarInventario",
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

export const editarInventario = createAsyncThunk("inventario/editarInventario",
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
