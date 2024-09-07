import { createSlice } from "@reduxjs/toolkit";
import { listarProveedor, obtenerProveedor } from '../actions/actionProveedor';

const initialState = {
  proveedores: [],
  proveedor: {},
  loading: false,
  error: null,
};

const ProveedorSlice = createSlice({
  name: "getProveedor",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(listarProveedor.pending, (state) => {
        state.proveedores = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(listarProveedor.fulfilled, (state, action) => {
        state.proveedores = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(listarProveedor.rejected, (state, action) => {
        state.proveedores = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(obtenerProveedor.pending, (state) => {
        state.proveedor = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(obtenerProveedor.fulfilled, (state, action) => {
        state.proveedor = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(obtenerProveedor.rejected, (state, action) => {
        state.proveedor = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getProveedorReducer = ProveedorSlice.reducer;